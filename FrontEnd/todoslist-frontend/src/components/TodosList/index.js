import { useEffect, useRef, useState } from "react";
import { addTodosApi, delTodosApi, editTodosApi, getTodosApi } from "../../api/todo";
import "./index.css";

const TodosList = () => {
  const [todos, SetTodos] = useState([]);
  const [textBtn, SetTextBtn] = useState("THÊM MỚI");
  const todoRef = useRef([]);

  useEffect(() => {
    fetchData();
  }, []);

  const fetchData = async () => {
    SetTodos(await getTodosApi());
  };

  const delTodos = async (id) => {
    if (window.confirm("Bạn có muốn xoá hay không")) {
      await delTodosApi(id);
      window.location.reload();
    }
  };

  const AddorEditTodos = async (event) => {
    event.preventDefault();
    const value = event.target[0].value;
    const id = event.target[1].value;
    console.log(value, id);
    if (id) {
      // Update
      await editTodosApi({
        name: value,
        id: id
      });
      todoRef.current[id].className = "fas fa-edit";
    } else {
      // New
      await addTodosApi({
        name: value,
      });
    }
    fetchData();
    event.target[0].value = "";
    event.target[1].value = null;
    SetTextBtn("THÊM MỚI");
  };

  const editTodo =  (id) => {
    console.log("asd");

    todoRef?.current.forEach((item) => {
      if(item.getAttribute("data-id") && item.getAttribute("data-id") !== String(id)) {
        item.className = "fas fa-edit";
      }
    });

    const inputName = document.getElementById("name");
    const inputId = document.getElementById("id");

    if(todoRef?.current[id].className === "fas fa-edit"){
      todoRef.current[id].className = "fas fa-user-edit"
      SetTextBtn("CẬP NHẬT");
      inputName.value = todoRef.current[id].getAttribute("data-name");
      inputId.value = id;
    }else if(todoRef?.current[id].className === "fas fa-user-edit"){
      todoRef.current[id].className = "fas fa-edit";
      SetTextBtn("THÊM MỚI");
      inputName.value = "";
      inputId.value = null;
    }

  }

  const onIsComplete = async (todo) =>{
    await editTodosApi({
      ...todo,
      isComplete: true
    });
    fetchData();
  }

  return (
    <main id="todolist">
      <h1>
        Danh sách
        <span>Việc hôm nay không để ngày mai.</span>
      </h1>
      {todos ? (
        todos?.map((item, key) => (
          <li className={item.isComplete ? "done" : ""} key={key} onDoubleClick={()=> onIsComplete(item)}>
            <span className="label">{item.name}</span>
            <div className="actions">
              <button
                className="btn-picto"
                type="button"
                onClick={() => editTodo(item.id)
                }
              >
                <i 
                className="fas fa-edit" 
                ref={el => todoRef.current[item.id] = el} 
                data-name = {item.name}
                data-id = {item.id}
                />
              </button>
              <button
                className="btn-picto"
                type="button"
                aria-label="Delete"
                title="Delete"
                onClick={() => delTodos(item.id)}
              >
                <i className="fas fa-trash" />
              </button>
            </div>
          </li>
        ))
      ) : (
        <p>Danh sách nhiệm vụ trống.</p>
      )}
      <form onSubmit={AddorEditTodos}>
        <label>Thêm nhiệm vụ mới</label>
        <input type="text" name="name" id="name" />
        <input type="text" name="id" id="id" style={{display: "none"}}/>
        <button type="submit">{textBtn}</button>
      </form>
    </main>
  );
};

export default TodosList;
