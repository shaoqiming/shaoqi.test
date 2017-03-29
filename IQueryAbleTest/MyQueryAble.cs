using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IQueryAbleTest
{
    class MyQueryAble<T> : IQueryable<T>
    {

        public MyQueryAble()
        {
            this._provider = new MyQueryProvider();
            this._expression = Expression.Constant(this);
        }

        public MyQueryAble(Expression expression)
        {
            this._provider = new MyQueryProvider();
            this._expression = expression;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetEnumerator(Provider.Execute(Expression) as IEnumerable);
        }

        IEnumerator<T> GetEnumerator(IEnumerable able)
        {
            var result = _provider.Execute<List<T>>(_expression);
            if (result == null)
                yield break;
            foreach (var item in result)
            {
                yield return item;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public Type ElementType
        {
            get { return typeof(T); }
        }
        public System.Linq.Expressions.Expression _expression;
        public System.Linq.Expressions.Expression Expression
        {
            get { return _expression; }
        }

        public IQueryProvider _provider;
        public IQueryProvider Provider
        {
            get { return _provider; }
        }
    }

    class MyQueryProvider : IQueryProvider
    {

        public IQueryable<TElement> CreateQuery<TElement>(System.Linq.Expressions.Expression expression)
        {
            return new MyQueryAble<TElement>(expression);
        }

        public IQueryable CreateQuery(System.Linq.Expressions.Expression expression)
        {
            throw new NotImplementedException();
        }

        public TResult Execute<TResult>(System.Linq.Expressions.Expression expression)
        {
            List<LambdaExpression> lambda = null;
            Program.AnalysisExpression2(expression, ref lambda);

            IEnumerable<Student> enumerable = null;

            for (int i = 0; i < lambda.Count; i++)
            {
                Func<Student, bool> func = (lambda[i] as Expression<Func<Student, bool>>).Compile();//通过Compile将表达式转化位委托
            }




                return default(TResult);
        }

        public object Execute(System.Linq.Expressions.Expression expression)
        {
            return new List<object>();
        }
    }
}
