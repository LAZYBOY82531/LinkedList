﻿using System;
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

		public MyLinkedListNode(T value)                //오버로드 정의
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


		public MyLinkedList<T> List { get { return list; } }                //연결리스트의 리스트 불러오는 함수 정의
		public MyLinkedListNode<T> Prev { get { return prev; } }    //연결리스트에서 앞의 값을 불러오는 함수 정의
		public MyLinkedListNode<T> Next { get { return next; } }   //연결리스트에서 뒤의 값을 불러오는 함수 정의
		public T Value { get { return data; } set { data = value; } }    //연결리스트에서 값을 저장하거나 불러오는 함수를 정의
	}
	public class MyLinkedList<T>                                                  //연결리스트 정의
	{
		private MyLinkedListNode<T> head;                                  //함수에서만 사용되는 해드와 테일 정의
		private MyLinkedListNode<T> tail;
		private int count = 0;                                                          //함수에서만 사용되는 count정의

		public MyLinkedListNode<T> First { get { return head; } }  //연결리스트의 head출력하는 함수
		public MyLinkedListNode<T> Last { get { return tail; } }      //연결리스트의 tail출력하는 함수
		public int Count { get { return count; } }                              //연결리스트의 count출력하는 함수

		public void AddFirst(T value)                                            //연결리스트의 맨앞에 값을 추가하는 함수
		{
			//1, 새로운 노드 생성
			MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(this, value);   //T value를 연결리스트에 넣을 수 있는 값으로 변환

			if(head != null)                                    //넣으려는 연결리스트에 head값이 있을 때
            { 
				newNode.next = head;                    //넣으려는 newNode의 다음 값으로 head지정
				head.prev = newNode;                    //원래 연결리스트의 맨 앞의 값인 head 앞의 값으로 newNode지정
            }
            else                                                   //넣으려는 연결리스트에 head값이 없을 때 즉 연결리스트가 비어있을 때
            {
				head = newNode;                           //빈 연결리스트에 값이 새로 추가되며 newNode가 head값이자 tail값이 된다.
				tail = newNode;
            }
			head = newNode;                               //연결리스트의 head값을 newNode로 바꿈
			count++;                                             //값이 추가되었으니 count값을 올린다.
		}
		public void AddLast(T value)                       //연결리스트의 맨 뒤에 T value값을 추가하는 함수
		{
			//1, 새로운 노드 생성
			MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(this, value);

			if (tail != null)                                     //넣으려는 연결리스트에 tail값이 있을 때
			{
				newNode.prev = tail;					  //넣으려는 newNode의 이전 값으로 tail지정
				tail.next = newNode;					  //원래 연결리스트의 맨 뒤의 값인 tail 앞의 값으로 newNode지정
			}
			else												   //넣으려는 연결리스트에 tail값이 없을 때 즉 연결리스트가 비어있을 때
			{
				head = newNode;							  //빈 연결리스트에 값이 새로 추가되며 newNode가 head값이자 tail값이 된다.
				tail = newNode;
			}
			tail = newNode;									 //연결리스트의 tail값을 newNode로 바꿈
			count++;											 //값이 추가되었으니 count값을 올린다.
		}
		public MyLinkedListNode<T> Find(T value)          //연결리스트에서 T value값을 찾는 함수
		{
			MyLinkedListNode<T> target = head;                                               //맨 앞 값을 임의 지정
			EqualityComparer<T> comparer = EqualityComparer<T>.Default;        //EqualityComparer를 사용하기 위해 정의
			if (value != null)                                                                                 //value값이 비어있다면 함수를 계산할 이유가 없기에 걸러줌
			{
				while (target != null)                                                                     //연결리스트가 비어있다면 함수를 계산할 이유가 없기에 걸러줌
				{
					if (comparer.Equals(target.data, value))                                    //연결리스트의 값과 찾으려는 값을 비교
						return target;                                                                      //같다면 값을 return하고 함수 종료
					else
						target = target.next;                                                            //다르다면 다음 값으로 함수를 반복
				}
			}
			return null;
		}
		public void AddBefore(MyLinkedListNode<T> target, T value)           //연결리스트의 target값의 이전값으로 T value값을 넣는 함수
		{
			if (target.List != this)             //예외1 : 노드가 연결리스트에 포함되어 있지 않은 경우
				throw new InvalidOperationException();
			if (target == null)                   //예외2 : 노드가 null인 경우
				throw new ArgumentNullException(nameof(target));
			MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(this, value);    //T value를 연결리스트에 넣을 수 있는 값으로 변환
			newNode.next = target;                                  //newNode의 다음 값으로 target 지정
			if (target.prev != null)                                     //target의 이전 값이 있다면
			{
				newNode.prev = target.prev;                      //target의 이전값을 newNode의 이전 값으로 지정
				target.prev.next = newNode;                      //target의 이전값의 다음값을 newNode로 지정
			}
			target.prev = newNode;                                 //target의 이전 값을 newNode로 지정
			count++;                                                        //newNode가 연결리스트에 추가되었으니 count증가
		}
		public void AddAfter(MyLinkedListNode<T> target, T value)           //연결리스트의 target값의 다음으로 T value값을 넣는 함수
		{
			if (target.List != this) //예외1 : 노드가 연결리스트에 포함되어 있지 않은 경우
				throw new InvalidOperationException();
			if (target == null)  //예외2 : 노드가 null인 경우
				throw new ArgumentNullException(nameof(target));
			MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(this, value);    //T value를 연결리스트에 넣을 수 있는 값으로 변환
			newNode.prev = target;                         //newNode의 이전 값으로 target 지정
			if (target.next != null)						    //target의 다음 값이 있다면
			{
				newNode.next = target.next;			     //target의 다음값을 newNode의 다음 값으로 지정
				target.next.prev = newNode;			     //target의 다음값의 이전값을 newNode로 지정
			}
			target.next = newNode;						  //target의 다음 값을 newNode로 지정
			count++;											   //newNode가 연결리스트에 추가되었으니 count증가
		}
		public void Remove(MyLinkedListNode<T> value)           //연결리스트의 value값을 없애는 함수
		{
			if (value.List != this) //예외1 : 노드가 연결리스트에 포함되어 있지 않은 경우
				throw new InvalidOperationException();
			if (value == null)  //예외2 : 노드가 null인 경우
				throw new ArgumentNullException(nameof(value));

			//0, 지웟을 때 head나 tail 이 변경되는 경우
			if (head == value)
				head = value.next;
			if (tail == value)
				tail = value.prev;
			//1, 연결구조 바꾸기
			if (value.prev != null)
				value.prev.next = value.next;
			if (value.next != null)
				value.next.prev = value.prev;

			//2, 실제로 노드를 삭제하기
			count--;
		}

		public bool Remove(T value)                     //연결리스트에 T value값이 있다면 true값을 반환하고 지우고, 없다면 false를 반환하는 함수
		{
			MyLinkedListNode<T> node = Find(value);        //연결리스트에서 T value값을 찾음
			if (node != null)                                                 //연결리스트에 value값이 있다면
			{
				Remove(node);                                             //value값을 삭제
				return true;                                                 //true값을 반환
			}
			else                                                                 //연결리스트에 value값이 없다면
			{
				return false;                                                //false값을 반환
			}
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
