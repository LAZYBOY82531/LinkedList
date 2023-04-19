using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructure
{
    public class LinkedListNode<T>
	{ 
		internal LinkedList<T> list;
		internal LinkedListNode<T> prev;
        internal LinkedListNode<T> next;
        private T data;

		public LinkedListNode(T value)
		{
			this.list = null;
			this.prev = null;
			this.next = null;
			this.data = value;
		}

		public LinkedListNode(LinkedList<T> list, T value)
		{
			this.list = list;
			this.prev = null;
			this.next = null;
			this.data = value;
		}

		public LinkedListNode(LinkedList<T> list, LinkedListNode<T> prev, LinkedListNode<T> next, T value)
		{
			this.list = list;
			this.prev = prev;
			this.next = next;
			this.data = value;
		}


		public LinkedList<T> List { get { return list; } }
        public LinkedListNode<T> Prev { get { return prev; } }
        public LinkedListNode<T> Next { get { return next; } }
        public T Value { get { return data; } set { data = value; } }
    }
    public class LinkedList<T>
    {
		private LinkedListNode<T> head;
		private LinkedListNode<T> tail;
		private int count;

		public LinkedListNode<T> First { get { return head; } }
		public LinkedListNode<T> Last { get { return tail; } }
		public int Count { get { return count; } }

		public LinkedListNode<T> AddFirst(T value)
        {
			//1, 새로운 노드 생성
			LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

			//2, 연결구조 바꾸기
			//2-1, head노드가 있었을 때
			if (head != null)
			{
				newNode.next = head;
				head.prev = newNode;
			}
            else
			//2-2, head노드가 없을 때
            {
				head = newNode;
				tail = newNode;
            }

			//3, 새로운 노드를 head 노드로 지정
			head = newNode;
			count++;
			return newNode;
        }
    }
}
