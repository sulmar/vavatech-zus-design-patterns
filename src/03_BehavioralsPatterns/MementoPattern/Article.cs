using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace MementoPattern
{
    public class Article
    {
        public string Content { get; set; }
        public string Title { get; set; }

        // Backup
        public ArticleMemento CreateMemento()
        {
            return new ArticleMemento(this.Title, this.Content);
        }

        // Restore
        public void SetMemento(ArticleMemento memento)
        {
            this.Title = memento.Title;
            this.Content = memento.Content;
        }
    }


    // Migawka (snapshot)
    public class ArticleMemento
    {
        public string Content { get; }
        public string Title { get; }
        public DateTime SnapshotDate { get; }

        public ArticleMemento(string content, string title)
        {
            Content = content;
            Title = title;
            SnapshotDate = DateTime.UtcNow;
        }

        public override string ToString()
        {
            return $"{SnapshotDate} {Title} : {Content}";
        }
    }

    // Abstract Caretaker (nadzorca)
    public interface IArticleCaretaker
    {
        void SetState(ArticleMemento memento);
        ArticleMemento GetState();
    }

    // Concrete Caretaker
    public class StackArticleCaretaker : IArticleCaretaker
    {
        private Stack<ArticleMemento> mementos = new Stack<ArticleMemento>();

        public ArticleMemento GetState()
        {
            return mementos.Pop();
        }

        public void SetState(ArticleMemento memento)
        {
            mementos.Push(memento);
        }
    }
   
}
