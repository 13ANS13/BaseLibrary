﻿using System;
using System.Diagnostics;
using System.Linq;

namespace BaseLibrary.Tool.Extensions
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Get inner exception message
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static string GetInnerExceptionMessage(
            this Exception exception
        )
        {
            Exception eDetail = exception;

            while (eDetail.InnerException != null)
                eDetail = eDetail.InnerException;

            return eDetail.Message;
        }

        /// <summary>
        /// Get exception path
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static string GetExceptionPath(
            this Exception exception
        )
        {
            StackTrace trace = new StackTrace(exception, true);

            if (trace == null)
            {
                return string.Empty;
            }

            var frame = trace.GetFrames().LastOrDefault();

            var errorPath = frame.GetMethod().ReflectedType.FullName;
            var errorLine = frame.GetFileLineNumber();
            var errorLineColumn = frame.GetFileColumnNumber();

            return $"Method Path: {errorPath}, Method Exception Line: {errorLine}, Method Exception Line Column: {errorLineColumn}";
        }

        /// <summary>
        /// Get normalized exception
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="addNewLine"></param>
        /// <returns></returns>
        public static string GetNormalizedException(
            this Exception exception,
            bool addNewLine = false
        )
        {
            if (exception == null)
            {
                return string.Empty;
            }

            return $"{(addNewLine ? " \n " : "")}Exception Path: \n {exception.GetExceptionPath()} \n\n Exception Message: \n {exception.GetInnerExceptionMessage()} \n";
        }
    }
}