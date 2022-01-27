using System.Collections.Generic;
using System.Linq;

namespace AGCI.AuxClasses
{
    public class TreeNavigator<T> where T : ITreeNode
    {
        public IEnumerable<T> GetChildrens(T node)
        {
            var cola = new Queue<T>();
            var subordinados = new List<T>();
            cola.Enqueue(node);
            while (cola.Count > 0)
            {
                var item = cola.Dequeue();
                foreach (var child in item.GetChildrens().Select(treeNode => (T) treeNode))
                {
                    subordinados.Add(child);
                    cola.Enqueue(child);
                }
            }
            return subordinados;
        }

        public IEnumerable<T> GetSuperiors(T node)
        {
            var iterar = node;
            var superiores = new List<T>();
            while (iterar != null)
            {
                iterar = (T) iterar.GetParent();
                if (iterar != null)
                {
                    superiores.Add(iterar);
                }
            }
            return superiores;
        }

        public T GetRoot(T node)
        {
            var iterar = node;
            var root = node;
            while (iterar != null)
            {
                iterar = (T)iterar.GetParent();
                if (iterar != null)
                {
                    root = iterar;
                }
            }
            return root;
        }
    }
}