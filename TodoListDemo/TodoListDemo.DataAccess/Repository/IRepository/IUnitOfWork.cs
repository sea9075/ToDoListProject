using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListDemo.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ITodoListRepository TodoList { get; }
        void Save();
    }
}
