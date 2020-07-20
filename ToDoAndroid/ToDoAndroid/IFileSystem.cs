using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoAndroid
{
    /// <summary>
    /// this interface inside ToDoAndroi
    /// </summary>
    public interface IFileSystem
    {
        string GetExternalStorage();
        string GetSpecialFolder();
    }
}
