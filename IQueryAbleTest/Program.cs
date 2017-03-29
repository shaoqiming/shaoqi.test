using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IQueryAbleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Student stu = new Student() { name = "ss", age = 1 };

            Func<Student, bool> func = (t) => { return t.name == "shaoqi"; };
            //表达式树
            Expression<Func<Student, bool>> expression = t => t.name == "农码一生" && t.age == 2;

            AnalysisExpression(expression);

            bool d = func(stu);
            Console.WriteLine(d.ToString());

            var aa = new MyQueryAble<Student>();
            var bb = aa.Where(t => t.name == "邵祺");
            var cc = bb.Where(t => t.age == 1);
            var dd = cc.AsEnumerable();
            var ee = cc.ToList();
            Console.ReadKey();
        }


        public static void AnalysisExpression(Expression exper)
        {
            switch (exper.NodeType)
            {
                case ExpressionType.Call://执行方法
                    MethodCallExpression method = exper as MethodCallExpression;
                    Console.WriteLine("方法名:" + method.Method.Name);
                    for (int i = 0; i < method.Arguments.Count; i++)
                    {
                        AnalysisExpression(method.Arguments[i]);
                    }
                    ; break;

                case ExpressionType.Lambda://lambda 表达式
                    LambdaExpression lambda = exper as LambdaExpression;
                    AnalysisExpression(lambda.Body);
                    ; break;


                case ExpressionType.Equal:
                case ExpressionType.AndAlso:
                    BinaryExpression binary = exper as BinaryExpression;
                    Console.WriteLine("运算符：" + exper.NodeType.ToString());
                    AnalysisExpression(binary.Left);
                    AnalysisExpression(binary.Right);
                    ; break;

                case ExpressionType.Constant:
                    ConstantExpression constant = exper as ConstantExpression;
                    Console.WriteLine("常量值:" + constant.Value.ToString());
                    ; break;

                case ExpressionType.MemberAccess:
                    MemberExpression Member = exper as MemberExpression;
                    Console.WriteLine("字段名称:{0}，类型:{1}", Member.Member.Name, Member.Type.ToString()); ; break;

                default: Console.WriteLine("UnKnow"); break;
            }
        }

        public static void AnalysisExpression2(Expression exper, ref List<LambdaExpression> lambdaout)
        {
            if (lambdaout == null)
                lambdaout = new List<LambdaExpression>();

            switch (exper.NodeType)
            {
                case ExpressionType.Call://执行方法
                    MethodCallExpression method = exper as MethodCallExpression;
                    Console.WriteLine("方法名:" + method.Method.Name);
                    for (int i = 0; i < method.Arguments.Count; i++)
                    {
                        AnalysisExpression2(method.Arguments[i], ref lambdaout);
                    }
                    ; break;

                case ExpressionType.Lambda://lambda 表达式
                    LambdaExpression lambda = exper as LambdaExpression;
                    lambdaout.Add(lambda);
                    AnalysisExpression2(lambda.Body, ref lambdaout);
                    ; break;


                case ExpressionType.Equal:
                case ExpressionType.AndAlso:
                    BinaryExpression binary = exper as BinaryExpression;
                    Console.WriteLine("运算符：" + exper.NodeType.ToString());
                    AnalysisExpression2(binary.Left, ref lambdaout);
                    AnalysisExpression2(binary.Right, ref lambdaout);
                    ; break;

                case ExpressionType.Constant:
                    ConstantExpression constant = exper as ConstantExpression;
                    Console.WriteLine("常量值:" + constant.Value.ToString());
                    ; break;

                case ExpressionType.MemberAccess:
                    MemberExpression Member = exper as MemberExpression;
                    Console.WriteLine("字段名称:{0}，类型:{1}", Member.Member.Name, Member.Type.ToString()); ; break;

                case ExpressionType.Quote:
                    UnaryExpression Unary = exper as UnaryExpression;
                    AnalysisExpression2(Unary.Operand, ref  lambdaout);
                    break;

                default: Console.WriteLine("UnKnow"); break;
            }

        }
    }

    class Student
    {
        public string name { get; set; }
        public int age { get; set; }
    }
}
