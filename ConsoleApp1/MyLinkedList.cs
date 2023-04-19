using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructure
{
	public class MyLinkedListNode<T>
	{
		internal MyLinkedList<T> list;
		internal MyLinkedListNode<T> prev;
		internal MyLinkedListNode<T> next;
		internal T data;

		public MyLinkedListNode(T value)
		{
			this.list = null;
			this.prev = null;
			this.next = null;
			this.data = value;
		}

		public MyLinkedListNode(MyLinkedList<T> list, T value)
		{
			this.list = list;
			this.prev = null;
			this.next = null;
			this.data = value;
		}

		public MyLinkedListNode(MyLinkedList<T> list, MyLinkedListNode<T> prev, MyLinkedListNode<T> next, T value)
		{
			this.list = list;
			this.prev = prev;
			this.next = next;
			this.data = value;
		}


		public MyLinkedList<T> List { get { return list; } }
		public MyLinkedListNode<T> Prev { get { return prev; } }
		public MyLinkedListNode<T> Next { get { return next; } }
		public T Value { get { return data; } set { data = value; } }
	}
	public class MyLinkedList<T>
	{
		private MyLinkedListNode<T> head;
		private MyLinkedListNode<T> tail;
		private int count = 0;

		public MyLinkedListNode<T> First { get { return head; } }
		public MyLinkedListNode<T> Last { get { return tail; } }
		public int Count { get { return count; } }

		public void AddFirst(T value)
		{
			//1, 새로운 노드 생성
			MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(this, value);

			if(head != null)
            {
				newNode.next = head;
				head.prev = newNode;
            }
            else
            {
				head = newNode;
				tail = newNode;
            }
			head = newNode;
			count++;
		}
		public void AddLast(T value)
		{
			//1, 새로운 노드 생성
			MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(this, value);

			if (tail != null)
			{
				newNode.prev = tail;
				tail.next = newNode;
			}
			else
			{
				head = newNode;
				tail = newNode;
			}
			tail = newNode;
			count++;
		}
		
	}
	//링크드 리스트 기술면접 조사
	/*링크드리스트: 각각의 데이터가 노드로 연결되어 구성된 자료구조. 배열과 유사하나 삽입,삭제에서 유리하다. 
	 * 배열은 삽입,삭제시 전,후로 있는 인덱스들을 모두 밀거나 당겨줘야 하지만 링크드리스트는 삽입,삭제시 앞,뒤로 가르키는 노드의 위치만 
	 * 변경해주면 된다.연결 리스트(MyLinkedList)
	 - 노드마다 다음 노드의 주소를 가지고 있다.
	 - 연결되지 않은 메모리를 사용한다.
	 - 장점 : 추가, 삭제 비용이 적다. (메모리 주소만 고쳐 써주면 된다)
	 - 단점 : 탐색을 할 때 비용이 높아진다.
		랜덤 액세스(N번째 요소에 접근)하려면 앞에서부터 순서대로 찾아야 한다.*/
}
