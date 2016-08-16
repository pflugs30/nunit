// ***********************************************************************
// Copyright (c) 2011 Charlie Poole
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

using System;
using NUnit.Framework.Constraints;

namespace NUnit.Framework
{
    /// <summary>
    /// The Assert class contains a collection of static methods that
    /// implement the most common assertions used in NUnit.
    /// </summary>
    public partial class Assert
    {
        #region Assert.That

        #region Boolean

        /// <summary>
        /// Asserts that a condition is true. If the condition is false the method throws
        /// an <see cref="AssertionException"/>.
        /// </summary>
        /// <param name="condition">The evaluated condition</param>
        public static void That(bool condition)
        {
            Assert.That(condition, Is.True, null, null);
        }

        /// <summary>
        /// Asserts that a condition is true. If the condition is false the method throws
        /// an <see cref="AssertionException"/>.
        /// </summary>
        /// <param name="condition">The evaluated condition</param>
        /// <param name="getExceptionMessage">A function to build the message included with the Exception</param>
        public static void That(bool condition, Func<ConstraintResult, string> getExceptionMessage)
        {
            Assert.That(condition, Is.True, getExceptionMessage);
        }

        /// <summary>
        /// Asserts that a condition is true. If the condition is false the method throws
        /// an <see cref="AssertionException"/>.
        /// </summary>
        /// <param name="condition">The evaluated condition</param>
        /// <param name="getExceptionMessage">A function to build the message included with the Exception</param>
        public static void That(bool condition, Func<string> getExceptionMessage)
        {
            Assert.That(condition, Is.True, getExceptionMessage);
        }

        /// <summary>
        /// Asserts that a condition is true. If the condition is false the method throws
        /// an <see cref="AssertionException"/>.
        /// </summary> 
        /// <param name="condition">The evaluated condition</param>
        /// <param name="message">The message to display if the condition is false</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        public static void That(bool condition, string message, params object[] args)
        {
            Assert.That(condition, Is.True, message, args);
        }

        #endregion

        #region Lambda returning Boolean
#if !NET_2_0
        /// <summary>
        /// Asserts that a condition is true. If the condition is false the method throws
        /// an <see cref="AssertionException"/>.
        /// </summary> 
        /// <param name="condition">A lambda that returns a Boolean</param>
        /// <param name="message">The message to display if the condition is false</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        public static void That(Func<bool> condition, string message, params object[] args)
        {
            Assert.That(condition.Invoke(), Is.True, message, args);
        }

        /// <summary>
        /// Asserts that a condition is true. If the condition is false the method throws
        /// an <see cref="AssertionException"/>.
        /// </summary> 
        /// <param name="condition">A lambda that returns a Boolean</param>
        /// <param name="getExceptionMessage">A function to build the message included with the Exception</param>
        public static void That(Func<bool> condition, Func<ConstraintResult, string> getExceptionMessage)
        {
            Assert.That(condition.Invoke(), Is.True, getExceptionMessage);
        }

        /// <summary>
        /// Asserts that a condition is true. If the condition is false the method throws
        /// an <see cref="AssertionException"/>.
        /// </summary> 
        /// <param name="condition">A lambda that returns a Boolean</param>
        /// <param name="getExceptionMessage">A function to build the message included with the Exception</param>
        public static void That(Func<bool> condition, Func<string> getExceptionMessage)
        {
            Assert.That(condition.Invoke(), Is.True, getExceptionMessage);
        }

        /// <summary>
        /// Asserts that a condition is true. If the condition is false the method throws
        /// an <see cref="AssertionException"/>.
        /// </summary>
        /// <param name="condition">A lambda that returns a Boolean</param>
        public static void That(Func<bool> condition)
        {
            Assert.That(condition.Invoke(), Is.True, null, null);
        }
#endif
        #endregion

        #region ActualValueDelegate

        /// <summary>
        /// Apply a expression to an actual value, succeeding if the expression
        /// is satisfied and throwing an assertion exception on failure.
        /// </summary>
        /// <typeparam name="TActual">The type of the <see cref="ActualValueDelegate{TActual}"/></typeparam>
        /// <param name="actual">An ActualValueDelegate returning the value to be tested</param>
        /// <param name="expression">A Constraint expression to be applied</param>
        public static void That<TActual>(ActualValueDelegate<TActual> actual, IResolveConstraint expression)
        {
            Assert.That(actual, expression, null, null);
        }

        /// <summary>
        /// Apply a expression to an actual value, succeeding if the expression
        /// is satisfied and throwing an assertion exception on failure.
        /// </summary>
        /// <typeparam name="TActual">The type of the <see cref="ActualValueDelegate{TActual}"/></typeparam>
        /// <param name="actual">An ActualValueDelegate returning the value to be tested</param>
        /// <param name="expression">A Constraint expression to be applied</param>
        /// <param name="getExceptionMessage">A function to build the message included with the Exception</param>
        public static void That<TActual>(ActualValueDelegate<TActual> actual, IResolveConstraint expression, Func<ConstraintResult, string> getExceptionMessage)
        {
            Assert.That<ActualValueDelegate<TActual>>(actual, expression, getExceptionMessage);
        }

        /// <summary>
        /// Apply a expression to an actual value, succeeding if the expression
        /// is satisfied and throwing an assertion exception on failure.
        /// </summary>
        /// <typeparam name="TActual">The type of the <see cref="ActualValueDelegate{TActual}"/></typeparam>
        /// <param name="actual">An ActualValueDelegate returning the value to be tested</param>
        /// <param name="expression">A Constraint expression to be applied</param>
        /// <param name="getExceptionMessage">A function to build the message included with the Exception</param>
        public static void That<TActual>(ActualValueDelegate<TActual> actual, IResolveConstraint expression, Func<string> getExceptionMessage)
        {
            Assert.That<ActualValueDelegate<TActual>>(actual, expression, getExceptionMessage);
        }

        /// <summary>
        /// Apply a expression to an actual value, succeeding if the expression
        /// is satisfied and throwing an assertion exception on failure.
        /// </summary>
        /// <typeparam name="TActual">The type of the <see cref="ActualValueDelegate{TActual}"/></typeparam>
        /// <param name="actual">An ActualValueDelegate returning the value to be tested</param>
        /// <param name="expression">A Constraint expression to be applied</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        public static void That<TActual>(ActualValueDelegate<TActual> actual, IResolveConstraint expression, string message, params object[] args)
        {
            Assert.That<ActualValueDelegate<TActual>>(actual, expression, message, args);
        }

        #endregion

        #region TestDelegate

        /// <summary>
        /// Asserts that the actual represented by a delegate throws an exception
        /// that satisfies the expression provided.
        /// </summary>
        /// <param name="actual">A TestDelegate to be executed</param>
        /// <param name="expression">A ThrowsConstraint used in the test</param>
        public static void That(TestDelegate actual, IResolveConstraint expression)
        {
            Assert.That(actual, expression, null, null);
        }

        /// <summary>
        /// Asserts that the actual represented by a delegate throws an exception
        /// that satisfies the expression provided.
        /// </summary>
        /// <param name="actual">A TestDelegate to be executed</param>
        /// <param name="expression">A ThrowsConstraint used in the test</param>
        /// <param name="getExceptionMessage">A function to build the message included with the Exception</param>
        public static void That(TestDelegate actual, IResolveConstraint expression, Func<ConstraintResult, string> getExceptionMessage)
        {
            Assert.That<TestDelegate>(actual, expression, getExceptionMessage);
        }

        /// <summary>
        /// Asserts that the actual represented by a delegate throws an exception
        /// that satisfies the expression provided.
        /// </summary>
        /// <param name="actual">A TestDelegate to be executed</param>
        /// <param name="expression">A ThrowsConstraint used in the test</param>
        /// <param name="getExceptionMessage">A function to build the message included with the Exception</param>
        public static void That(TestDelegate actual, IResolveConstraint expression, Func<string> getExceptionMessage)
        {
            Assert.That<TestDelegate>(actual, expression, getExceptionMessage);
        }

        /// <summary>
        /// Asserts that the actual represented by a delegate throws an exception
        /// that satisfies the expression provided.
        /// </summary>
        /// <param name="actual">A TestDelegate to be executed</param>
        /// <param name="expression">A ThrowsConstraint used in the test</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        public static void That(TestDelegate actual, IResolveConstraint expression, string message, params object[] args)
        {
            Assert.That<TestDelegate>(actual, expression, message, args);
        }

        #endregion

        #endregion

        #region Assert.That<TActual>

        /// <summary>
        /// Apply a expression to an actual value, succeeding if the expression
        /// is satisfied and throwing an assertion exception on failure.
        /// </summary>
        /// <typeparam name="TActual">The type of <paramref name="actual"/></typeparam>
        /// <param name="actual">The actual value to test</param>
        /// <param name="expression">A Constraint to be applied</param>
        public static void That<TActual>(TActual actual, IResolveConstraint expression)
        {
            Assert.That(actual, expression, null, null);
        }

        /// <summary>
        /// Apply a expression to an actual value, succeeding if the expression
        /// is satisfied and throwing an assertion exception on failure.
        /// </summary>
        /// <typeparam name="TActual">The type of <paramref name="actual"/></typeparam>
        /// <param name="actual">The actual value to test</param>
        /// <param name="expression">A Constraint expression to be applied</param>
        /// <param name="getExceptionMessage">A function to build the message included with the Exception</param>
        public static void That<TActual>(TActual actual, IResolveConstraint expression, Func<ConstraintResult, string> getExceptionMessage)
        {
            var constraint = expression.Resolve();

            IncrementAssertCount();
            var result = constraint.ApplyTo(actual);
            if (!result.IsSuccess)
            {
                throw new AssertionException(getExceptionMessage(result));
            }
        }

        /// <summary>
        /// Apply a expression to an actual value, succeeding if the expression
        /// is satisfied and throwing an assertion exception on failure.
        /// </summary>
        /// <typeparam name="TActual">The type of <paramref name="actual"/></typeparam>
        /// <param name="actual">The actual value to test</param>
        /// <param name="expression">A Constraint expression to be applied</param>
        /// <param name="getExceptionMessage">A function to build the message included with the Exception</param>
        public static void That<TActual>(TActual actual, IResolveConstraint expression, Func<string> getExceptionMessage)
        {
            Assert.That(actual, expression, BuildExceptionMessageFuncIgnoringConstraintResult(getExceptionMessage));
        }

        /// <summary>
        /// Apply a expression to an actual value, succeeding if the expression
        /// is satisfied and throwing an assertion exception on failure.
        /// </summary>
        /// <typeparam name="TActual">The type of <paramref name="actual"/></typeparam>
        /// <param name="actual">The actual value to test</param>
        /// <param name="expression">A Constraint expression to be applied</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        public static void That<TActual>(TActual actual, IResolveConstraint expression, string message, params object[] args)
        {
            Assert.That(actual, expression, BuildDefaultExceptionMessageFunc(message, args));
        }

        #endregion

        #region Assert.ByVal

        /// <summary>
        /// Apply a expression to an actual value, succeeding if the expression
        /// is satisfied and throwing an assertion exception on failure.
        /// Used as a synonym for That in rare cases where a private setter 
        /// causes a Visual Basic compilation error.
        /// </summary>
        /// <param name="actual">The actual value to test</param>
        /// <param name="expression">A Constraint to be applied</param>
        public static void ByVal(object actual, IResolveConstraint expression)
        {
            Assert.That(actual, expression, null, null);
        }

        /// <summary>
        /// Apply a expression to an actual value, succeeding if the expression
        /// is satisfied and throwing an assertion exception on failure. 
        /// Used as a synonym for That in rare cases where a private setter 
        /// causes a Visual Basic compilation error.
        /// </summary>
        /// <remarks>
        /// This method is provided for use by VB developers needing to test
        /// the value of properties with private setters.
        /// </remarks>
        /// <param name="actual">The actual value to test</param>
        /// <param name="expression">A Constraint expression to be applied</param>
        /// <param name="getExceptionMessage">A function to build the message included with the Exception</param>
        public static void ByVal(object actual, IResolveConstraint expression, Func<ConstraintResult, string> getExceptionMessage)
        {
            Assert.That(actual, expression, getExceptionMessage);
        }

        /// <summary>
        /// Apply a expression to an actual value, succeeding if the expression
        /// is satisfied and throwing an assertion exception on failure. 
        /// Used as a synonym for That in rare cases where a private setter 
        /// causes a Visual Basic compilation error.
        /// </summary>
        /// <remarks>
        /// This method is provided for use by VB developers needing to test
        /// the value of properties with private setters.
        /// </remarks>
        /// <param name="actual">The actual value to test</param>
        /// <param name="expression">A Constraint expression to be applied</param>
        /// <param name="getExceptionMessage">A function to build the message included with the Exception</param>
        public static void ByVal(object actual, IResolveConstraint expression, Func<string> getExceptionMessage)
        {
            Assert.That(actual, expression, getExceptionMessage);
        }

        /// <summary>
        /// Apply a expression to an actual value, succeeding if the expression
        /// is satisfied and throwing an assertion exception on failure. 
        /// Used as a synonym for That in rare cases where a private setter 
        /// causes a Visual Basic compilation error.
        /// </summary>
        /// <remarks>
        /// This method is provided for use by VB developers needing to test
        /// the value of properties with private setters.
        /// </remarks>
        /// <param name="actual">The actual value to test</param>
        /// <param name="expression">A Constraint expression to be applied</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        public static void ByVal(object actual, IResolveConstraint expression, string message, params object[] args)
        {
            Assert.That(actual, expression, message, args);
        }

        #endregion
    }
}
