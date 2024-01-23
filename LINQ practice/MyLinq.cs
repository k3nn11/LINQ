using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_practice
{
    public static class MyLinq
    {
        public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach(var item in source)
            {
                if (predicate(item)) yield return item;
            }
        }

        public static IEnumerable<TResult> MySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach( var item in source)
            { 
                yield return selector(item);
            }
        }

        public static IEnumerable<TResult> MySelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selectors)
        {
            foreach ( var item in source)
            {
                foreach (var  item2 in selectors(item))
                {
                    yield return item2;
                }
            }
        }

        public static int MySum<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }
            if (source == null)
            {
                throw new ArgumentNullException (nameof(source));
            }
            int num = 0;
            foreach (var item in source)
            {
                num += selector(item);
            }
            return num;
        }

        public static TSource MySingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException();
            }

            int num = 0;
            var val = default(TSource);
            foreach (var item in source)
            {           

                if (predicate(item))
                {
                    num++;
                    if (num > 1)
                    {
                        throw new Exception("More than one match");
                    }
                    val = item;
                    continue; 
                }
            }
            return val;
        }

        public static Dictionary<TKey, TSource> MyToDictionary<TKey, TSource>(this IEnumerable<TSource> source, Func<TSource, TKey> Selector)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (Selector == null)
            { 
                throw new ArgumentNullException(nameof(Selector));
            }
            var dictionary = new Dictionary<TKey, TSource>();
            foreach ( var item in source)
            {
                dictionary.Add(Selector(item), item);
            }
            return dictionary;
        }
        public static IEnumerable<TSource> MyOrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (keySelector == null)
            {
                throw new ArgumentNullException(nameof(keySelector));
            }
            List <TSource> list = new List<TSource>(source);
            int count = list.Count;

            for (var i = 0; i < count - 1; i++)
            {
                for (var j = 0; j < count - i - 1; j++)
                {
                    TKey key1 = keySelector(list[j]);
                    TKey key2 = keySelector(list[j + 1]);

                    if (Comparer<TKey>.Default.Compare(key1, key2) > 0)
                    {
                        var item = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = item;
                    }
                }
            }
            return list;
        }
    }
}

