﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ArcWaitWindow
{
    /// <summary>
    /// Displays a window telling the user to wait while a process is executing.
    /// </summary>
    public class ArcWaitWindow
    {
        /// <summary>
        /// Shows a wait window with the text 'Please wait...' while executing the passed method.
        /// </summary>
        /// <param name="workerMethod">Pointer to the method to execute while displaying the wait window.</param>
        /// <returns>The result argument from the worker method.</returns>
        public static object Show(EventHandler<ArcWaitWindowEventArgs> workerMethod)
        {
            return Show(workerMethod, null);
        }

        /// <summary>
        /// Shows a wait window with the specified text while executing the passed method.
        /// </summary>
        /// <param name="workerMethod">Pointer to the method to execute while displaying the wait window.</param>
        /// <param name="message">The text to display.</param>
        /// <returns>The result argument from the worker method.</returns>
        public static object Show(EventHandler<ArcWaitWindowEventArgs> workerMethod, string message)
        {
            var instance = new ArcWaitWindow();
            return instance.Show(workerMethod, message, new List<object>());
        }

        /// <summary>
        /// Shows a wait window with the specified text while executing the passed method.
        /// </summary>
        /// <param name="workerMethod">Pointer to the method to execute while displaying the wait window.</param>
        /// <param name="message">The text to display.</param>
        /// <param name="args">Arguments to pass to the worker method.</param>
        /// <returns>The result argument from the worker method.</returns>
        public static object Show(EventHandler<ArcWaitWindowEventArgs> workerMethod, string message, params object[] args)
        {
            var arguments = new List<object>();
            arguments.AddRange(args);

            var instance = new ArcWaitWindow();
            return instance.Show(workerMethod, message, arguments);
        }

        #region Instance implementation

        private ArcWaitWindow()
        {
        }

        private WaitWindowGui _gui;

        internal delegate void MethodInvoker<in T>(T parameter1);

        internal EventHandler<ArcWaitWindowEventArgs> WorkerMethod;
        internal List<object> Args;

        /// <summary>
        /// Updates the message displayed in the wait window.
        /// </summary>
        public string Message
        {
            set => _gui.Invoke(new MethodInvoker<string>(_gui.SetMessage), value);
        }

        /// <summary>
        /// Cancels the work and exits the wait windows immediately
        /// </summary>
        public void Cancel()
        {
            _gui.Invoke(new MethodInvoker(_gui.Cancel), null);
        }

        private object Show(EventHandler<ArcWaitWindowEventArgs> workerMethod, string message, List<object> args)
        {
            //	Validate Parameters

            WorkerMethod = workerMethod ?? throw new ArgumentException("No worker method has been specified.", nameof(workerMethod));

            Args = args;

            if (string.IsNullOrEmpty(message))
            {
                message = "Please wait...";
            }

            //	Set up the window
            _gui = new WaitWindowGui(this)
            {
                MessageLabel =
                {
                    Text = message
                }
            };

            //	Call it
            _gui.ShowDialog();

            var result = _gui.Result;

            //	clean up
            var error = _gui.Error;
            _gui.Dispose();

            //	Return result or throw and exception
            if (error != null)
            {
                throw error;
            }

            return result;
        }

        #endregion Instance implementation
    }
}