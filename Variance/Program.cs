using System.IO;

namespace Variance
{
    internal class Program
    {
        private static void Main()
        {
            // Covariance - inherited to base.
            IGenericCovariant<MemoryStream> test = new A<MemoryStream>();
            IGenericCovariant<Stream> test2 = test;
            Stream stream = test.Do();

            // Contravariance  - base to inherited.
            // Basically Stream is not implicitly converted to FileStream.
            // But it does if 
            IGenericContravariant<Stream> test3 = new B<Stream>();
            IGenericContravariant<FileStream> test4 = test3;
            test3.Do(new MemoryStream());
        }
    }

    public interface IGenericCovariant<out T>
    {
        T Do();
    }

    public interface IGenericContravariant<in T>
    {
        void Do(T t);
    }

    public class A<T> : IGenericCovariant<T> where T : new()
    {
        public T Do()
        {
            return new T();
        }
    }

    public class B<T> : IGenericContravariant<T>
    {
        public void Do(T t)
        {
            
        }
    }
}
