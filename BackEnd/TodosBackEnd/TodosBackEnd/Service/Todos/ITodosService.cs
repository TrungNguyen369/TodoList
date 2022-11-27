using TodosBackEnd.models;

namespace TodosBackEnd.Service.Todos
{
    public interface ITodosService
    {
        List<Todo> GetTodos();
        Boolean AddTodos(Todo todo);
        Boolean UpdateTodos(Todo todo);
        Boolean DelTodos(int id);

    }
}
