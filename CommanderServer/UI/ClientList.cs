using CSharpExtendedCommands.Web.Communication;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;

namespace CommanderServer.UI
{
    public partial class ClientList : IList, ICollection, IEnumerable
    {
        public ClientList()
        {

        }

        public object this[int index] { get => innerClients[index]; set { if (value.GetType() == typeof(TCPClient)) innerClients[index] = (TCPClient)value; else if (value.GetType() == typeof(Socket)) innerClients[index] = new TCPClient((Socket)value); } }

        public bool IsReadOnly => false;

        public bool IsFixedSize => false;
        private List<TCPClient> innerClients = new List<TCPClient>();
        public int Count => innerClients.Count;

        public object SyncRoot => null;

        public bool IsSynchronized => false;
        public int Add(object client)
        {

            if (client.GetType() == typeof(TCPClient))
            {
                innerClients.Add((TCPClient)client);
                return 1;
            }
            else if (client.GetType() == typeof(Socket))
            {
                innerClients.Add(new TCPClient((Socket)client));
                return 1;
            }
            else
                return 0;
        }

        public void Clear()
        {
            innerClients.Clear();
        }

        public bool Contains(object value)
        {
            if (value.GetType() == typeof(TCPClient))
                return innerClients.Contains((TCPClient)value);
            else if (value.GetType() == typeof(Socket))
                return innerClients.Contains(new TCPClient((Socket)value));
            return false;
        }

        public void CopyTo(Array array, int index)
        {
            innerClients.CopyTo((TCPClient[])array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return innerClients.GetEnumerator();
        }

        public int IndexOf(object value)
        {
            if (value.GetType() == typeof(Socket))
                return innerClients.IndexOf(new TCPClient((Socket)value));
            else if (value.GetType() == typeof(TCPClient))
                return innerClients.IndexOf((TCPClient)value);
            else return -1;
        }

        public void Insert(int index, object client)
        {
            if (client.GetType() == typeof(TCPClient))
                innerClients.Insert(index, (TCPClient)client);
            else if (client.GetType() == typeof(Socket))
                innerClients.Insert(index, new TCPClient((Socket)client));
        }

        public void Remove(object value)
        {
            if (value.GetType() == typeof(TCPClient))
                innerClients.Remove((TCPClient)value);
            else if (value.GetType() == typeof(Socket))
                innerClients.Remove(new TCPClient((Socket)value));
        }

        public void RemoveAt(int index)
        {
            innerClients.RemoveAt(index);
        }
    }
}
