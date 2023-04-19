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
        internal T data;

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
		private int count = 0;

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

		public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
		{
			if (node.List != this) //예외1 : 노드가 연결리스트에 포함되어 있지 않은 경우
				throw new InvalidOperationException();
			if (node == null)  //예외2 : 노드가 null인 경우
				throw new ArgumentNullException(nameof(node));
			//1, 새로운 노드 만들기
			LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

			//2, 연결주고 바꾸기
			newNode.next = node;
			newNode.prev = node.prev;
			node.prev.next = newNode;
			if (node.prev != null)
				node.prev = newNode;

			//3, 갯수 증가
			count++;
			return newNode;
		}

		public void Remove(LinkedListNode<T> node)
		{
			if(node.List != this) //예외1 : 노드가 연결리스트에 포함되어 있지 않은 경우
				throw new InvalidOperationException();
			if(node == null)  //예외2 : 노드가 null인 경우
				throw new ArgumentNullException(nameof(node));

			//0, 지웟을 때 head나 tail 이 변경되는 경우
			if (head == node)
				head = node.next;
			if (tail == node)
				tail = node.prev;
			//1, 연결구조 바꾸기
			if (node.prev != null)
				node.prev.next = node.next;
			if(node.next != null)
				node.next.prev = node.prev;

			//2, 실제로 노드를 삭제하기
			count--;
        }

		public bool Remove(T value)
        {
			LinkedListNode<T> node = Find(value);
			if (node != null)
			{
				Remove(node);
				return true;
			}
			else
			{
				return false;
			}
		}

		public LinkedListNode<T> Find(T value)
		{
			LinkedListNode<T> target = head;
			EqualityComparer<T> comparer = EqualityComparer<T>.Default;
			if (value != null)
			{
				while (target != null)
				{
					if (comparer.Equals(target.data, value))
						return target;
					else
						target = target.next;
				}
			}
			else
			{
				while (target != null)
				{
					if (target.data == null)
						return target;
					else
						target = target.next;
				}
			}
			return null;
		}
		//링크드 리스트 기술면접 조사
		/*링크드리스트: 각각의 데이터가 노드로 연결되어 구성된 자료구조. 배열과 유사하나 삽입,삭제에서 유리하다. 
		 * 배열은 삽입,삭제시 전,후로 있는 인덱스들을 모두 밀거나 당겨줘야 하지만 링크드리스트는 삽입,삭제시 앞,뒤로 가르키는 노드의 위치만 
		 * 변경해주면 된다.연결 리스트(LinkedList)
		 - 노드마다 다음 노드의 주소를 가지고 있다.
	     - 연결되지 않은 메모리를 사용한다.
		 - 장점 : 추가, 삭제 비용이 적다. (메모리 주소만 고쳐 써주면 된다)
		 - 단점 : 탐색을 할 때 비용이 높아진다.
            랜덤 액세스(N번째 요소에 접근)하려면 앞에서부터 순서대로 찾아야 한다.*/
	}
}
