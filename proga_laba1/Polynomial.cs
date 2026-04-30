using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proga_laba1
{
    internal class Polynomial
    {             // Приватное поле для хранения коэффициентов
            private readonly double[] _coefficients;

            /// <summary>
            /// Коллекция коэффициентов (только для чтения)
            /// </summary>
            public IReadOnlyList<double> Coefficients => _coefficients;

            /// <summary>
            /// Степень многочлена (только для чтения)
            /// </summary>
            public int Degree { get; }

            /// <summary>
            /// Конструктор с параметрами, необходимыми для инициализации объекта.
            /// Принимает коэффициенты от младшей степени к старшей.
            /// </summary>
            public Polynomial(params double[] coefficients)
            {
                if (coefficients == null || coefficients.Length == 0)
                    throw new ArgumentException("Многочлен должен иметь хотя бы один коэффициент.");

                // Убираем ведущие нули
                int lastNonZero = coefficients.Length - 1;
                while (lastNonZero >= 0 && Math.Abs(coefficients[lastNonZero]) < 1e-10)
                    lastNonZero--;

                if (lastNonZero < 0)
                {
                    // Нулевой многочлен
                    _coefficients = new double[] { 0 };
                    Degree = 0;
                }
                else
                {
                    _coefficients = new double[lastNonZero + 1];
                    Array.Copy(coefficients, _coefficients, lastNonZero + 1);
                    Degree = lastNonZero;
                }
            }

            /// <summary>
            /// Вычисление значения многочлена в точке x.
            /// </summary>
            public double Evaluate(double x)
            {
                // Схема Горнера
                double result = 0;
                for (int i = _coefficients.Length - 1; i >= 0; i--)
                {
                    result = result * x + _coefficients[i];
                }
                return result;
            }

            #region Арифметические операторы
            public static Polynomial operator +(Polynomial left, Polynomial right)
            {
                if (left is null) throw new ArgumentNullException(nameof(left));
                if (right is null) throw new ArgumentNullException(nameof(right));

                int maxDegree = Math.Max(left.Degree, right.Degree);
                double[] result = new double[maxDegree + 1];

                for (int i = 0; i <= maxDegree; i++)
                {
                    double leftCoef = i < left._coefficients.Length ? left._coefficients[i] : 0;
                    double rightCoef = i < right._coefficients.Length ? right._coefficients[i] : 0;
                    result[i] = leftCoef + rightCoef;
                }

                return new Polynomial(result);
            }

            public static Polynomial operator -(Polynomial left, Polynomial right)
            {
                if (left is null) throw new ArgumentNullException(nameof(left));
                if (right is null) throw new ArgumentNullException(nameof(right));

                int maxDegree = Math.Max(left.Degree, right.Degree);
                double[] result = new double[maxDegree + 1];

                for (int i = 0; i <= maxDegree; i++)
                {
                    double leftCoef = i < left._coefficients.Length ? left._coefficients[i] : 0;
                    double rightCoef = i < right._coefficients.Length ? right._coefficients[i] : 0;
                    result[i] = leftCoef - rightCoef;
                }

                return new Polynomial(result);
            }

            public static Polynomial operator *(Polynomial left, Polynomial right)
            {
                if (left is null) throw new ArgumentNullException(nameof(left));
                if (right is null) throw new ArgumentNullException(nameof(right));

                int resultDegree = left.Degree + right.Degree;
                double[] result = new double[resultDegree + 1];

                for (int i = 0; i < left._coefficients.Length; i++)
                {
                    for (int j = 0; j < right._coefficients.Length; j++)
                    {
                        result[i + j] += left._coefficients[i] * right._coefficients[j];
                    }
                }

                return new Polynomial(result);
            }
            #endregion

            #region Операторы сравнения
            public static bool operator ==(Polynomial left, Polynomial right)
            {
                if (ReferenceEquals(left, right)) return true;
                if (left is null || right is null) return false;

                if (left.Degree != right.Degree) return false;

                for (int i = 0; i <= left.Degree; i++)
                {
                    if (Math.Abs(left._coefficients[i] - right._coefficients[i]) > 1e-10)
                        return false;
                }
                return true;
            }

            public static bool operator !=(Polynomial left, Polynomial right)
            {
                return !(left == right);
            }
            #endregion

            #region Переопределение методов Object
            public override string ToString()
            {
                if (Degree == 0 && Math.Abs(_coefficients[0]) < 1e-10)
                    return "0";

                var terms = new List<string>();

                for (int i = Degree; i >= 0; i--)
                {
                    double coef = _coefficients[i];
                    if (Math.Abs(coef) < 1e-10) continue;

                    string term = FormatTerm(coef, i, terms.Count == 0);
                    terms.Add(term);
                }

                return terms.Count > 0 ? string.Join(" ", terms) : "0";
            }

            private string FormatTerm(double coef, int degree, bool isFirst)
            {
                string sign;
                double absCoef = Math.Abs(coef);

                if (isFirst)
                {
                    sign = coef < 0 ? "-" : "";
                }
                else
                {
                    sign = coef < 0 ? "- " : "+ ";
                }

                string coefStr;
                if (degree == 0)
                {
                    coefStr = absCoef.ToString("0.###");
                }
                else if (Math.Abs(absCoef - 1.0) < 1e-10)
                {
                    coefStr = "";
                }
                else
                {
                    coefStr = absCoef.ToString("0.###");
                }

            string varPart;
            if (degree == 0)
                varPart = "";
            else if (degree == 1)
                varPart = "x";
            else
                varPart = $"x^{degree}";

            if (degree > 0 && Math.Abs(absCoef - 1.0) < 1e-10)
                    return sign + varPart;
                else if (degree > 0)
                    return sign + coefStr + varPart;
                else
                    return sign + coefStr;
            }

            public override bool Equals(object obj)
            {
                if (obj is null) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj is Polynomial other)
                    return this == other;
                return false;
            }

            public override int GetHashCode()
            {
                int hash = 17;
                foreach (var c in _coefficients)
                {
                    hash = hash * 31 + Math.Round(c, 6).GetHashCode();
                }
                return hash;
            }
            #endregion
        }
    }