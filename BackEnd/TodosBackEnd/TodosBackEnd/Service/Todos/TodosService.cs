using TodosBackEnd.Data;
using TodosBackEnd.models;

namespace TodosBackEnd.Service.Todos
{
    public class TodosService : ITodosService
    {
        private readonly TodosDbContext _todosDbContext;

        public TodosService(TodosDbContext todosDbContext)
        {
            _todosDbContext = todosDbContext;
        }

        public bool AddTodos(Todo todo)
        {
            _todosDbContext.todos.Add(todo);
            _todosDbContext.SaveChanges();
            return true;
        }

        public bool DelTodos(int id)
        {
            Todo todo = _todosDbContext.todos.Find(id);
            _todosDbContext.todos.Remove(todo);
            _todosDbContext.SaveChanges();
            return true;
        }

        public List<Todo> GetTodos()
        {
            return _todosDbContext.todos.OrderByDescending(x => x.Id).ToList();
        }

        public bool UpdateTodos(Todo todo)
        {
            _todosDbContext.todos.Update(todo);
            _todosDbContext.SaveChanges();
            return true;
        }
    }
}
