using System.Collections.Generic;

namespace Web.Common
{
    public class MessageStacker
    {
        public MessageStacker()
        {
        }

        private void Ensure(object value)
        {
            if (!m_Values.ContainsKey(value)) m_Values[value] = new List<string>();
        }

        public void Add(object value, string _message)
        {
            Ensure(value);
            m_Values[value].Add(_message);
        }

        public IList<string> GetList(object value)
        {
            Ensure(value);
            return m_Values[value];
        }

        public SortedList<object, List<string>> List { get { return m_Values; } }

        private SortedList<object, List<string>> m_Values = new SortedList<object,List<string>>();
    }
}