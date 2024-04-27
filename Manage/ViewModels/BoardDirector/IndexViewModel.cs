using Core.Models;
using System.Collections.Generic;

namespace Manage.ViewModels.BoardDirector
{
    public class IndexViewModel
    {
        public List<Manager> BoardDirectors { get; set; }
        public BoardDirectorComponent BoardDirectorComponent { get; set; }
    }
}
