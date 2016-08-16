// ***********************************************************************
// Copyright (c) 2014 Charlie Poole
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
        #region Throws

        /// <summary>
        /// Verifies that a delegate throws a particular exception when called.
        /// </summary>
        /// <param name="expression">A constraint to be satisfied by the exception</param>
        /// <param name="code">A TestSnippet delegate</param>
        /// <param name="getExceptionMessage">A function to build the message included with the Exception</param>
        /// <returns>The exception (if any) returned from the code</returns>
        public static Exception Throws(IResolveConstraint expression, TestDelegate code, Func<ConstraintResult, string> getExceptionMessage)
        {
            var caughtException = CatchException(code);
            Assert.That(caughtException, expression, getExceptionMessage);
            return caughtException;
        }

        /// <summary>
        /// Verifies that a delegate throws a particular exception when called.
        /// </summary>
        /// <param name="expression">A constraint to be satisfied by the exception</param>
        /// <param name="code">A TestSnippet delegate</param>
        /// <param name="getExceptionMessage">A function to build the message included with the Exception</param>
        /// <returns>The exception (if any) returned from the code</returns>
        public static Exception Throws(IResolveConstraint expression, TestDelegate code, Func<string> getExceptionMessage)
        {
            var caughtException = CatchException(code);
            Assert.That(caughtException, expression, getExceptionMessage);
            return caughtException;
        }

        /// <summary>
        /// Verifies that a delegate throws a particular exception when called.
        /// </summary>
        /// <param name="expression">A constraint to be satisfied by the exception</param>
        /// <param name="code">A TestSnippet delegate</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        /// <returns>The exception (if any) returned from the code</returns>
        public static Exception Throws(IResolveConstraint expression, TestDelegate code, string message, params object[] args)
        {
            var caughtException = CatchException(code);
            Assert.That(caughtException, expression, message, args);
            return caughtException;
        }

        /// <summary>
        /// Verifies that a delegate throws a particular exception when called.
        /// </summary>
        /// <param name="expression">A constraint to be satisfied by the exception</param>
        /// <param name="code">A TestSnippet delegate</param>
        /// <returns>The exception (if any) returned from the code</returns>
        public static Exception Throws(IResolveConstraint expression, TestDelegate code)
        {
            return Throws(expression, code, string.Empty, null);
        }

        /// <summary>
        /// Verifies that a delegate throws a particular exception when called.
        /// </summary>
        /// <param name="expectedExceptionType">The exception Type expected</param>
        /// <param name="code">A TestDelegate</param>
        /// <param name="getExceptionMessage">A function to build the message included with the Exception</param>
        /// <returns>The exception (if any) returned from the code</returns>
        public static Exception Throws(Type expectedExceptionType, TestDelegate code, Func<ConstraintResult, string> getExceptionMessage)
        {
            return Throws(new ExceptionTypeConstraint(expectedExceptionType), code, getExceptionMessage);
        }

        /// <summary>
        /// Verifies that a delegate throws a particular exception when called.
        /// </summary>
        /// <param name="expectedExceptionType">The exception Type expected</param>
        /// <param name="code">A TestDelegate</param>
        /// <param name="getExceptionMessage">A function to build the message included with the Exception</param>
        /// <returns>The exception (if any) returned from the code</returns>
        public static Exception Throws(Type expectedExceptionType, TestDelegate code, Func<string> getExceptionMessage)
        {
            return Throws(new ExceptionTypeConstraint(expectedExceptionType), code, getExceptionMessage);
        }

        /// <summary>
        /// Verifies that a delegate throws a particular exception when called.
        /// </summary>
        /// <param name="expectedExceptionType">The exception Type expected</param>
        /// <param name="code">A TestDelegate</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        /// <returns>The exception (if any) returned from the code</returns>
        public static Exception Throws(Type expectedExceptionType, TestDelegate code, string message, params object[] args)
        {
            return Throws(new ExceptionTypeConstraint(expectedExceptionType), code, message, args);
        }

        /// <summary>
        /// Verifies that a delegate throws a particular exception when called.
        /// </summary>
        /// <param name="expectedExceptionType">The exception Type expected</param>
        /// <param name="code">A TestDelegate</param>
        /// <returns>The exception (if any) returned from the code</returns>
        public static Exception Throws(Type expectedExceptionType, TestDelegate code)
        {
            return Throws(new ExceptionTypeConstraint(expectedExceptionType), code, string.Empty, null);
        }

        #endregion

        #region Throws<TActual>

        /// <summary>
        /// Verifies that a delegate throws a particular exception when called.
        /// </summary>
        /// <typeparam name="TActual">Type of the expected exception</typeparam>
        /// <param name="code">A TestDelegate</param>
        /// <param name="getExceptionMessage">A function to build the message included with the Exception</param>
        /// <returns>The exception (if any) returned from the code</returns>
        public static TActual Throws<TActual>(TestDelegate code, Func<ConstraintResult, string> getExceptionMessage) where TActual : Exception
        {
            return (TActual)Throws(typeof(TActual), code, getExceptionMessage);
        }

        /// <summary>
        /// Verifies that a delegate throws a particular exception when called.
        /// </summary>
        /// <typeparam name="TActual">Type of the expected exception</typeparam>
        /// <param name="code">A TestDelegate</param>
        /// <param name="getExceptionMessage">A function to build the message included with the Exception</param>
        /// <returns>The exception (if any) returned from the code</returns>
        public static TActual Throws<TActual>(TestDelegate code, Func<string> getExceptionMessage) where TActual : Exception
        {
            return (TActual)Throws(typeof(TActual), code, getExceptionMessage);
        }

        /// <summary>
        /// Verifies that a delegate throws a particular exception when called.
        /// </summary>
        /// <typeparam name="TActual">Type of the expected exception</typeparam>
        /// <param name="code">A TestDelegate</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        /// <returns>The exception (if any) returned from the code</returns>
        public static TActual Throws<TActual>(TestDelegate code, string message, params object[] args) where TActual : Exception
        {
            return (TActual)Throws(typeof(TActual), code, message, args);
        }

        /// <summary>
        /// Verifies that a delegate throws a particular exception when called.
        /// </summary>
        /// <typeparam name="TActual">Type of the expected exception</typeparam>
        /// <param name="code">A TestDelegate</param>
        /// <returns>The exception (if any) returned from the code</returns>
        public static TActual Throws<TActual>(TestDelegate code) where TActual : Exception
        {
            return Throws<TActual>(code, string.Empty, null);
        }

        #endregion

        #region Catch
        
        /// <summary>
        /// Verifies that a delegate throws an exception when called and returns it.
        /// </summary>
        /// <param name="code">A TestDelegate</param>
        /// <param name="getExceptionMessage">A function to build the message included with the Exception</param>
        /// <returns>The exception (if any) returned from the code</returns>
        public static Exception Catch(TestDelegate code, Func<ConstraintResult, string> getExceptionMessage)
        {
            return Throws(new InstanceOfTypeConstraint(typeof(Exception)), code, getExceptionMessage);
        }

        /// <summary>
        /// Verifies that a delegate throws an exception when called and returns it.
        /// </summary>
        /// <param name="code">A TestDelegate</param>
        /// <param name="getExceptionMessage">A function to build the message included with the Exception</param>
        /// <returns>The exception (if any) returned from the code</returns>
        public static Exception Catch(TestDelegate code, Func<string> getExceptionMessage)
        {
            return Throws(new InstanceOfTypeConstraint(typeof(Exception)), code, getExceptionMessage);
        }

        /// <summary>
        /// Verifies that a delegate throws an exception when called and returns it.
        /// </summary>
        /// <param name="code">A TestDelegate</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        /// <returns>The exception (if any) returned from the code</returns>
        public static Exception Catch(TestDelegate code, string message, params object[] args)
        {
            return Throws(new InstanceOfTypeConstraint(typeof(Exception)), code, message, args);
        }

        /// <summary>
        /// Verifies that a delegate throws an exception when called and returns it.
        /// </summary>
        /// <param name="code">A TestDelegate</param>
        /// <returns>The exception (if any) returned from the code</returns>
        public static Exception Catch(TestDelegate code)
        {
            return Throws(new InstanceOfTypeConstraint(typeof(Exception)), code);
        }

        /// <summary>
        /// Verifies that a delegate throws an exception of a certain Type
        /// or one derived from it when called and returns it.
        /// </summary>
        /// <param name="expectedExceptionType">The expected Exception Type</param>
        /// <param name="code">A TestDelegate</param>
        /// <param name="getExceptionMessage">A function to build the message included with the Exception</param>
        /// <returns>The exception (if any) returned from the code</returns>
        public static Exception Catch(Type expectedExceptionType, TestDelegate code, Func<ConstraintResult, string> getExceptionMessage)
        {
            return Throws(new InstanceOfTypeConstraint(expectedExceptionType), code, getExceptionMessage);
        }

        /// <summary>
        /// Verifies that a delegate throws an exception of a certain Type
        /// or one derived from it when called and returns it.
        /// </summary>
        /// <param name="expectedExceptionType">The expected Exception Type</param>
        /// <param name="code">A TestDelegate</param>
        /// <param name="getExceptionMessage">A function to build the message included with the Exception</param>
        /// <returns>The exception (if any) returned from the code</returns>
        public static Exception Catch(Type expectedExceptionType, TestDelegate code, Func<string> getExceptionMessage)
        {
            return Throws(new InstanceOfTypeConstraint(expectedExceptionType), code, getExceptionMessage);
        }

        /// <summary>
        /// Verifies that a delegate throws an exception of a certain Type
        /// or one derived from it when called and returns it.
        /// </summary>
        /// <param name="expectedExceptionType">The expected Exception Type</param>
        /// <param name="code">A TestDelegate</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        /// <returns>The exception (if any) returned from the code</returns>
        public static Exception Catch(Type expectedExceptionType, TestDelegate code, string message, params object[] args)
        {
            return Throws(new InstanceOfTypeConstraint(expectedExceptionType), code, message, args);
        }

        /// <summary>
        /// Verifies that a delegate throws an exception of a certain Type
        /// or one derived from it when called and returns it.
        /// </summary>
        /// <param name="expectedExceptionType">The expected Exception Type</param>
        /// <param name="code">A TestDelegate</param>
        /// <returns>The exception (if any) returned from the code</returns>
        public static Exception Catch(Type expectedExceptionType, TestDelegate code)
        {
            return Throws(new InstanceOfTypeConstraint(expectedExceptionType), code);
        }
        
        #endregion

        #region Catch<TActual>

        /// <summary>
        /// Verifies that a delegate throws an exception of a certain Type
        /// or one derived from it when called and returns it.
        /// </summary>
        /// <typeparam name="TActual">The type of the Exception</typeparam>
        /// <param name="code">A TestDelegate</param>
        /// <param name="getExceptionMessage">A function to build the message included with the Exception</param>
        /// <returns>The exception (if any) returned from the code</returns>
        public static TActual Catch<TActual>(TestDelegate code, Func<ConstraintResult, string> getExceptionMessage) where TActual : Exception
        {
            return (TActual)Throws(new InstanceOfTypeConstraint(typeof(TActual)), code, getExceptionMessage);
        }

        /// <summary>
        /// Verifies that a delegate throws an exception of a certain Type
        /// or one derived from it when called and returns it.
        /// </summary>
        /// <typeparam name="TActual">The type of the Exception</typeparam>
        /// <param name="code">A TestDelegate</param>
        /// <param name="getExceptionMessage">A function to build the message included with the Exception</param>
        /// <returns>The exception (if any) returned from the code</returns>
        public static TActual Catch<TActual>(TestDelegate code, Func<string> getExceptionMessage) where TActual : Exception
        {
            return (TActual)Throws(new InstanceOfTypeConstraint(typeof(TActual)), code, getExceptionMessage);
        }

        /// <summary>
        /// Verifies that a delegate throws an exception of a certain Type
        /// or one derived from it when called and returns it.
        /// </summary>
        /// <typeparam name="TActual">The type of the Exception</typeparam>
        /// <param name="code">A TestDelegate</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        /// <returns>The exception (if any) returned from the code</returns>
        public static TActual Catch<TActual>(TestDelegate code, string message, params object[] args) where TActual : Exception
        {
            return (TActual)Throws(new InstanceOfTypeConstraint(typeof(TActual)), code, message, args);
        }

        /// <summary>
        /// Verifies that a delegate throws an exception of a certain Type
        /// or one derived from it when called and returns it.
        /// </summary>
        /// <typeparam name="TActual">The type of the Exception</typeparam>
        /// <param name="code">A TestDelegate</param>
        /// <returns>The exception (if any) returned from the code</returns>
        public static TActual Catch<TActual>(TestDelegate code) where TActual : Exception
        {
            return (TActual)Throws(new InstanceOfTypeConstraint(typeof(TActual)), code);
        }

        #endregion

        #region DoesNotThrow

        /// <summary>
        /// Verifies that a delegate does not throw an exception
        /// </summary>
        /// <param name="code">A TestDelegate</param>
        /// <param name="getExceptionMessage">A function to build the message included with the Exception</param>
        public static void DoesNotThrow(TestDelegate code, Func<ConstraintResult, string> getExceptionMessage)
        {
            Assert.That(code, new ThrowsNothingConstraint(), getExceptionMessage);
        }

        /// <summary>
        /// Verifies that a delegate does not throw an exception
        /// </summary>
        /// <param name="code">A TestDelegate</param>
        /// <param name="getExceptionMessage">A function to build the message included with the Exception</param>
        public static void DoesNotThrow(TestDelegate code, Func<string> getExceptionMessage)
        {
            Assert.That(code, new ThrowsNothingConstraint(), getExceptionMessage);
        }

        /// <summary>
        /// Verifies that a delegate does not throw an exception
        /// </summary>
        /// <param name="code">A TestDelegate</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        public static void DoesNotThrow(TestDelegate code, string message, params object[] args)
        {
            Assert.That(code, new ThrowsNothingConstraint(), message, args);
        }

        /// <summary>
        /// Verifies that a delegate does not throw an exception.
        /// </summary>
        /// <param name="code">A TestDelegate</param>
        public static void DoesNotThrow(TestDelegate code)
        {
            DoesNotThrow(code, string.Empty, null);
        }

        #endregion
    }
}
