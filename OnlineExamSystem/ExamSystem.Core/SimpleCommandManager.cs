using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Collections;
namespace ExamSystem.Core
{
    public class SimpleCommandManager
    {
        [ThreadStatic]
        private static SimpleCommandManager _commandManager;

        private List<WeakReference> _requerySuggestedHandlers;

        private static SimpleCommandManager Current
        {
            get
            {
                if (_commandManager == null)
                {
                    _commandManager = new SimpleCommandManager();
                }

                return _commandManager;
            }
        }

        public static event EventHandler RequerySuggested
        {
            add { SimpleCommandManager.AddWeakReferenceHandler(ref SimpleCommandManager.Current._requerySuggestedHandlers, value); }
            remove { SimpleCommandManager.RemoveWeakReferenceHandler(SimpleCommandManager.Current._requerySuggestedHandlers, value); }
        }
        internal static void AddWeakReferenceHandler(ref List<WeakReference> handlers, EventHandler handler)
        {
            if (handlers == null)
            {
                handlers = new List<WeakReference>();
            }

            handlers.Add(new WeakReference(handler));
        }
        internal static void RemoveWeakReferenceHandler(List<WeakReference> handlers, EventHandler handler)
        {
            if (handlers != null)
            {
                for (int i = handlers.Count - 1; i >= 0; i--)
                {
                    WeakReference reference = handlers[i];
                    EventHandler existingHandler = reference.Target as EventHandler;
                    if ((existingHandler == null) || (existingHandler == handler))
                    {
                        // Clean up old handlers that have been collected
                        // in addition to the handler that is to be removed. 
                        handlers.RemoveAt(i);
                    }
                }
            }
        }
    }
}
