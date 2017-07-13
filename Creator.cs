using System;
using System.Linq.Expressions;
using System.Reflection;

/// <summary>
/// Contains a factory of creating types with public constructors. The constructor lambda
/// is being created the first time and cached.
///
/// This package contains 2 versions being:
/// - Creator.Create<T>(object a, object b, ...)
/// - Creator.Create<T,A,B>(A a, B b)
/// 
/// </summary>
namespace Rsam70.Utils.Factory
{
    /// <summary>
    /// Delegate for executing a specfic constructor.
    /// </summary>
    public delegate T ObjectActivator<T>(params object[] args);

    /// <summary>
    /// Factory methods for creating dynamic objects, instead of using Activator.CreateInstance
    /// </summary>
    public static class Creator
    {     
        #region Cache and Creator functions
        public static T Create<T>() 
            where T:new() => new T();

        public static T Create<T>(object a)
        {
            var cache = new CacheObjectA<T>();
            return cache.Ctor(a);
        }

        public struct CacheObjectA<T>
        {
            private static ObjectActivator<T> ctorCache=null;

            public T Ctor(object a)
            {
                if (ctorCache==null)
                {
                    //Find the constructor
                    var types = new Type[]{a.GetType()};
                    var ctorInfo = GetConstructorInfo<T>(types);

                    // create the constructor lamda
                    ctorCache = GetActivator<T>(ctorInfo);
                }
                return ctorCache(a);
            }
        }

        public static T Create<T,A>(A a)
        {
            var cache = new CacheA<T,A>();
            return cache.Ctor(a);
        }

        public struct CacheA<T,A>
        {
            private static ObjectActivator<T> ctorCache=null;

            public T Ctor(A a)
            {
                if (ctorCache==null)
                {
                    //Find the constructor
                    var types = new Type[]{typeof(A)};
                    var ctorInfo = GetConstructorInfo<T>(types);

                    // create the constructor lamda
                    ctorCache = GetActivator<T>(ctorInfo);
                }
                return ctorCache(a);
            }
        }

        public static T Create<T>(object a,object b)
        {
            var cache = new CacheObjectAB<T>();
            return cache.Ctor(a,b);
        }

        public struct CacheObjectAB<T>
        {
            private static ObjectActivator<T> ctorCache=null;

            public T Ctor(object a,object b)
            {
                if (ctorCache==null)
                {
                    //Find the constructor
                    var types = new Type[]{a.GetType(),b.GetType()};
                    var ctorInfo = GetConstructorInfo<T>(types);

                    // create the constructor lamda
                    ctorCache = GetActivator<T>(ctorInfo);
                }
                return ctorCache(a,b);
            }
        }

        public static T Create<T,A,B>(A a,B b)
        {
            var cache = new CacheAB<T,A,B>();
            return cache.Ctor(a,b);
        }

        public struct CacheAB<T,A,B>
        {
            private static ObjectActivator<T> ctorCache=null;

            public T Ctor(A a,B b)
            {
                if (ctorCache==null)
                {
                    //Find the constructor
                    var types = new Type[]{typeof(A),typeof(B)};
                    var ctorInfo = GetConstructorInfo<T>(types);

                    // create the constructor lamda
                    ctorCache = GetActivator<T>(ctorInfo);
                }
                return ctorCache(a,b);
            }
        }

        public static T Create<T>(object a,object b,object c)
        {
            var cache = new CacheObjectABC<T>();
            return cache.Ctor(a,b,c);
        }

        public struct CacheObjectABC<T>
        {
            private static ObjectActivator<T> ctorCache=null;

            public T Ctor(object a,object b,object c)
            {
                if (ctorCache==null)
                {
                    //Find the constructor
                    var types = new Type[]{a.GetType(),b.GetType(),c.GetType()};
                    var ctorInfo = GetConstructorInfo<T>(types);

                    // create the constructor lamda
                    ctorCache = GetActivator<T>(ctorInfo);
                }
                return ctorCache(a,b,c);
            }
        }

        public static T Create<T,A,B,C>(A a,B b,C c)
        {
            var cache = new CacheABC<T,A,B,C>();
            return cache.Ctor(a,b,c);
        }

        public struct CacheABC<T,A,B,C>
        {
            private static ObjectActivator<T> ctorCache=null;

            public T Ctor(A a,B b,C c)
            {
                if (ctorCache==null)
                {
                    //Find the constructor
                    var types = new Type[]{typeof(A),typeof(B),typeof(C)};
                    var ctorInfo = GetConstructorInfo<T>(types);

                    // create the constructor lamda
                    ctorCache = GetActivator<T>(ctorInfo);
                }
                return ctorCache(a,b,c);
            }
        }

        public static T Create<T>(object a,object b,object c,object d)
        {
            var cache = new CacheObjectABCD<T>();
            return cache.Ctor(a,b,c,d);
        }

        public struct CacheObjectABCD<T>
        {
            private static ObjectActivator<T> ctorCache=null;

            public T Ctor(object a,object b,object c,object d)
            {
                if (ctorCache==null)
                {
                    //Find the constructor
                    var types = new Type[]{a.GetType(),b.GetType(),c.GetType(),d.GetType()};
                    var ctorInfo = GetConstructorInfo<T>(types);

                    // create the constructor lamda
                    ctorCache = GetActivator<T>(ctorInfo);
                }
                return ctorCache(a,b,c,d);
            }
        }

        public static T Create<T,A,B,C,D>(A a,B b,C c,D d)
        {
            var cache = new CacheABCD<T,A,B,C,D>();
            return cache.Ctor(a,b,c,d);
        }

        public struct CacheABCD<T,A,B,C,D>
        {
            private static ObjectActivator<T> ctorCache=null;

            public T Ctor(A a,B b,C c,D d)
            {
                if (ctorCache==null)
                {
                    //Find the constructor
                    var types = new Type[]{typeof(A),typeof(B),typeof(C),typeof(D)};
                    var ctorInfo = GetConstructorInfo<T>(types);

                    // create the constructor lamda
                    ctorCache = GetActivator<T>(ctorInfo);
                }
                return ctorCache(a,b,c,d);
            }
        }

        public static T Create<T>(object a,object b,object c,object d,object e)
        {
            var cache = new CacheObjectABCDE<T>();
            return cache.Ctor(a,b,c,d,e);
        }

        public struct CacheObjectABCDE<T>
        {
            private static ObjectActivator<T> ctorCache=null;

            public T Ctor(object a,object b,object c,object d,object e)
            {
                if (ctorCache==null)
                {
                    //Find the constructor
                    var types = new Type[]{a.GetType(),b.GetType(),c.GetType(),d.GetType(),e.GetType()};
                    var ctorInfo = GetConstructorInfo<T>(types);

                    // create the constructor lamda
                    ctorCache = GetActivator<T>(ctorInfo);
                }
                return ctorCache(a,b,c,d,e);
            }
        }

        public static T Create<T,A,B,C,D,E>(A a,B b,C c,D d,E e)
        {
            var cache = new CacheABCDE<T,A,B,C,D,E>();
            return cache.Ctor(a,b,c,d,e);
        }

        public struct CacheABCDE<T,A,B,C,D,E>
        {
            private static ObjectActivator<T> ctorCache=null;

            public T Ctor(A a,B b,C c,D d,E e)
            {
                if (ctorCache==null)
                {
                    //Find the constructor
                    var types = new Type[]{typeof(A),typeof(B),typeof(C),typeof(D),typeof(E)};
                    var ctorInfo = GetConstructorInfo<T>(types);

                    // create the constructor lamda
                    ctorCache = GetActivator<T>(ctorInfo);
                }
                return ctorCache(a,b,c,d,e);
            }
        }

        public static T Create<T>(object a,object b,object c,object d,object e,object f)
        {
            var cache = new CacheObjectABCDEF<T>();
            return cache.Ctor(a,b,c,d,e,f);
        }

        public struct CacheObjectABCDEF<T>
        {
            private static ObjectActivator<T> ctorCache=null;

            public T Ctor(object a,object b,object c,object d,object e,object f)
            {
                if (ctorCache==null)
                {
                    //Find the constructor
                    var types = new Type[]{a.GetType(),b.GetType(),c.GetType(),d.GetType(),e.GetType(),f.GetType()};
                    var ctorInfo = GetConstructorInfo<T>(types);

                    // create the constructor lamda
                    ctorCache = GetActivator<T>(ctorInfo);
                }
                return ctorCache(a,b,c,d,e,f);
            }
        }

        public static T Create<T,A,B,C,D,E,F>(A a,B b,C c,D d,E e,F f)
        {
            var cache = new CacheABCDEF<T,A,B,C,D,E,F>();
            return cache.Ctor(a,b,c,d,e,f);
        }

        public struct CacheABCDEF<T,A,B,C,D,E,F>
        {
            private static ObjectActivator<T> ctorCache=null;

            public T Ctor(A a,B b,C c,D d,E e,F f)
            {
                if (ctorCache==null)
                {
                    //Find the constructor
                    var types = new Type[]{typeof(A),typeof(B),typeof(C),typeof(D),typeof(E),typeof(F)};
                    var ctorInfo = GetConstructorInfo<T>(types);

                    // create the constructor lamda
                    ctorCache = GetActivator<T>(ctorInfo);
                }
                return ctorCache(a,b,c,d,e,f);
            }
        }

        public static T Create<T>(object a,object b,object c,object d,object e,object f,object g)
        {
            var cache = new CacheObjectABCDEFG<T>();
            return cache.Ctor(a,b,c,d,e,f,g);
        }

        public struct CacheObjectABCDEFG<T>
        {
            private static ObjectActivator<T> ctorCache=null;

            public T Ctor(object a,object b,object c,object d,object e,object f,object g)
            {
                if (ctorCache==null)
                {
                    //Find the constructor
                    var types = new Type[]{a.GetType(),b.GetType(),c.GetType(),d.GetType(),e.GetType(),f.GetType(),g.GetType()};
                    var ctorInfo = GetConstructorInfo<T>(types);

                    // create the constructor lamda
                    ctorCache = GetActivator<T>(ctorInfo);
                }
                return ctorCache(a,b,c,d,e,f,g);
            }
        }

        public static T Create<T,A,B,C,D,E,F,G>(A a,B b,C c,D d,E e,F f,G g)
        {
            var cache = new CacheABCDEFG<T,A,B,C,D,E,F,G>();
            return cache.Ctor(a,b,c,d,e,f,g);
        }

        public struct CacheABCDEFG<T,A,B,C,D,E,F,G>
        {
            private static ObjectActivator<T> ctorCache=null;

            public T Ctor(A a,B b,C c,D d,E e,F f,G g)
            {
                if (ctorCache==null)
                {
                    //Find the constructor
                    var types = new Type[]{typeof(A),typeof(B),typeof(C),typeof(D),typeof(E),typeof(F),typeof(G)};
                    var ctorInfo = GetConstructorInfo<T>(types);

                    // create the constructor lamda
                    ctorCache = GetActivator<T>(ctorInfo);
                }
                return ctorCache(a,b,c,d,e,f,g);
            }
        }

        public static T Create<T>(object a,object b,object c,object d,object e,object f,object g,object h)
        {
            var cache = new CacheObjectABCDEFGH<T>();
            return cache.Ctor(a,b,c,d,e,f,g,h);
        }

        public struct CacheObjectABCDEFGH<T>
        {
            private static ObjectActivator<T> ctorCache=null;

            public T Ctor(object a,object b,object c,object d,object e,object f,object g,object h)
            {
                if (ctorCache==null)
                {
                    //Find the constructor
                    var types = new Type[]{a.GetType(),b.GetType(),c.GetType(),d.GetType(),e.GetType(),f.GetType(),g.GetType(),h.GetType()};
                    var ctorInfo = GetConstructorInfo<T>(types);

                    // create the constructor lamda
                    ctorCache = GetActivator<T>(ctorInfo);
                }
                return ctorCache(a,b,c,d,e,f,g,h);
            }
        }

        public static T Create<T,A,B,C,D,E,F,G,H>(A a,B b,C c,D d,E e,F f,G g,H h)
        {
            var cache = new CacheABCDEFGH<T,A,B,C,D,E,F,G,H>();
            return cache.Ctor(a,b,c,d,e,f,g,h);
        }

        public struct CacheABCDEFGH<T,A,B,C,D,E,F,G,H>
        {
            private static ObjectActivator<T> ctorCache=null;

            public T Ctor(A a,B b,C c,D d,E e,F f,G g,H h)
            {
                if (ctorCache==null)
                {
                    //Find the constructor
                    var types = new Type[]{typeof(A),typeof(B),typeof(C),typeof(D),typeof(E),typeof(F),typeof(G),typeof(H)};
                    var ctorInfo = GetConstructorInfo<T>(types);

                    // create the constructor lamda
                    ctorCache = GetActivator<T>(ctorInfo);
                }
                return ctorCache(a,b,c,d,e,f,g,h);
            }
        }

        #endregion // cache and creator public construction        
        
        #region Creator logic
        /// <summary>
        /// Get constructor info based on types.
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public static ConstructorInfo GetConstructorInfo<T>(Type[] types)
        {            
            var dataType = typeof(T);
            ConstructorInfo constructorInfoObj = dataType.GetConstructor(
                BindingFlags.Instance | BindingFlags.Public, null,
                CallingConventions.HasThis, types, null);
            if (constructorInfoObj == null)
            {
                throw new Exception($"Cannot find a valid constructor for type {dataType}");
            }
            return constructorInfoObj;
        }

        /// <summary>
        /// Returns a lambda that constructs the type with given argument list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ctor"></param>
        /// <returns></returns>
        public static ObjectActivator<V> GetActivator<V> (ConstructorInfo ctor)
        {
            Type type = ctor.DeclaringType;
            ParameterInfo[] paramsInfo = ctor.GetParameters();

            //create a single param of type object[]
            ParameterExpression param =
                Expression.Parameter(typeof(object[]), "args");

            Expression[] argsExp =
                new Expression[paramsInfo.Length];

            //pick each arg from the params array 
            //and create a typed expression of them
            for (int i = 0; i < paramsInfo.Length; i++)
            {
                Expression index = Expression.Constant(i);
                Type paramType = paramsInfo[i].ParameterType;

                Expression paramAccessorExp =
                    Expression.ArrayIndex(param, index);

                Expression paramCastExp =
                    Expression.Convert(paramAccessorExp, paramType);

                argsExp[i] = paramCastExp;
            }

            //make a NewExpression that calls the
            //ctor with the args we just created
            NewExpression newExp = Expression.New(ctor, argsExp);

            //create a lambda with the New
            //Expression as body and our param object[] as arg
            LambdaExpression lambda =
                Expression.Lambda(typeof(ObjectActivator<V>), newExp, param);

            //compile it
            return (ObjectActivator<V>)lambda.Compile();
        }
        #endregion
    }
}