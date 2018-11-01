using System;

namespace Hachette.API.SDK.Utilities
{
    // <summary>
    /// Throw it in the trash if the value is wrong!
    /// </summary>
    public static class Trashcan
    {
        /// <summary>
        /// Throw <exception>InvalidOperationException</exception>, if the instance is null.
        /// USE whereby want to surface internal errors within an API.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="errorMessage"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        public static void InvalidProperty<T>(string name, string errorMessage, T value)
        where T : class
        {
            if(value == null)
            {
                throw new InvalidOperationException($"{errorMessage} -- Field affected: {name} ");
            }
        }

        /// <summary>
        /// Throw <exception>ArgumentNullException</exception>, if instance is null.
        /// USE when wanting to check Arguments passed into methods.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        public static void IsNull<T>(string name, T value)
        where T : class
        {
            if(value == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        /// <summary>
        /// Throw <see cref="InvalidOperationException" /> if 
        /// all objects are null.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="checkIfNull"></param>
        public static void AllAreNull(string errorMessage,params object[] checkIfNull)
        {
            if(checkIfNull.Length == 0)
                return;
            
            bool allNull = true;
            for(int i = 0;i < checkIfNull.Length;i++)
            {
                if(checkIfNull[i] != null)
                {
                    allNull = false; 
                    break;      
                }       
            }
            if(allNull)
            {
                throw new InvalidOperationException($"{errorMessage}");
            }
        }
        
    }
}