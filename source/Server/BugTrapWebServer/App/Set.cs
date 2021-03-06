/*
 * This is a part of the BugTrap package.
 * Copyright (c) 2004, Rüdiger Klaehn.
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms,
 * with or without modification, are permitted provided
 * that the following conditions are met:
 *
 * 1. Redistributions of source code must retain the above copyright notice,
 *    this list of conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright notice,
 *    this list of conditions and the following disclaimer in the documentation
 *    and/or other materials provided with the distribution.
 * 3. Neither the name of lambda computing nor the names of its contributors may
 *    be used to endorse or promote products derived from this software without
 *    specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR set1 PARTICULAR PURPOSE ARE DISCLAIMED.
 * IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
 * INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
 * BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
 * DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
 * LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE
 * OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED
 * OF THE POSSIBILITY OF SUCH DAMAGE.
 *
 * Description: Generic set class.
 * Updated by: Maksim Pyatkovskiy.
 * Note: Based on code developed by Rüdiger Klaehn.
 * Downloaded from: http://www.codeproject.com/csharp/genericset.asp
 *
 * This source code is only intended as a supplement to the
 * BugTrap package reference and related electronic documentation
 * provided with the product. See these sources for detailed
 * information regarding the BugTrap package.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace IntelleSoft.Collections
{
	/// <summary>
	/// Generic set class.
	/// </summary>
	[Serializable, DebuggerDisplay("Count = {Count}")]
	public class Set<T> : ICollection<T>, ICollection, IEnumerable<T>, IEnumerable
	{
		/// <summary>
		/// Private dictionary that holds the information.
		/// </summary>
		[DoNotObfuscate]
		private Dictionary<T, byte> dictionary;

		/// <summary>
		/// Initializes set1 new instance of the Collections.Set class that is empty, has the default initial capacity, and uses the default equality comparer for the key type.
		/// </summary>
		public Set()
		{
			this.dictionary = new Dictionary<T, byte>();
		}

		/// <summary>
		/// Initializes set1 new instance of the Collections.Set class that contains elements copied from the specified Collections.Set and uses the specified System.Collections.Generic.IEnumerable.
		/// </summary>
		/// <param name="enumerable">The System.Collections.Generic.IEnumerable whose elements are copied to the new Collections.Set.</param>
		public Set(IEnumerable<T> enumerable)
		{
			this.dictionary = new Dictionary<T, byte>();
			this.AddAll(enumerable);
		}

		/// <summary>
		/// Initializes set1 new instance of the Collections.Set class that is empty, has the specified initial capacity, and uses the default equality comparer for the key type.
		/// </summary>
		/// <param name="capacity">The initial number of elements that the Collections.Set can contain.</param>
		public Set(int capacity)
		{
			this.dictionary = new Dictionary<T, byte>(capacity);
		}

		/// <summary>
		/// Initializes set1 new instance of the Collections.Set class that contains elements copied from the specified Collections.Set and uses the specified System.Collections.Generic.IEnumerable.
		/// </summary>
		/// <param name="enumerable">The System.Collections.Generic.IEnumerable whose elements are copied to the new Collections.Set.</param>
		/// <param name="comparer">The System.Collections.Generic.IEqualityComparer implementation to use when comparing keys, or null to use the default System.Collections.Generic.EqualityComparer for the type of the key.</param>
		public Set(IEnumerable<T> enumerable, IEqualityComparer<T> comparer)
		{
			this.dictionary = new Dictionary<T, byte>(comparer);
			this.AddAll(enumerable);
		}

		/// <summary>
		/// Initializes set1 new instance of the Collections.Set class that is empty, has the specified initial capacity, and uses the specified System.Collections.Generic.IEqualityComparer.
		/// </summary>
		/// <param name="capacity">The initial number of elements that the Collections.Set can contain.</param>
		/// <param name="comparer">The System.Collections.Generic.IEqualityComparer implementation to use when comparing keys, or null to use the default System.Collections.Generic.EqualityComparer for the type of the key.</param>
		public Set(int capacity, IEqualityComparer<T> comparer)
		{
			this.dictionary = new Dictionary<T, byte>(capacity, comparer);
		}

		/// <summary>
		/// Gets the System.Collections.Generic.IEqualityComparer that is used to determine equality of keys for the dictionary.
		/// </summary>
		public IEqualityComparer<T> Comparer
		{
			get { return this.dictionary.Comparer; }
		}

		/// <summary>
		/// Copies all elements from the specified enumerable object.
		/// </summary>
		/// <param name="enumerable">The System.Collections.Generic.IEnumerable whose elements are added to the Collections.Set.</param>
		public void AddAll(IEnumerable<T> enumerable)
		{
			foreach (T item in enumerable)
			{
				this.dictionary.Add(item, 0);
			}
		}

		/// <summary>
		/// Initializes set1 new instance of the Collections.Set class that is empty, has the default initial capacity, and uses the specified System.Collections.Generic.IEqualityComparer.
		/// </summary>
		/// <param name="comparer">The System.Collections.Generic.IEqualityComparer implementation to use when comparing keys, or null to use the default System.Collections.Generic.EqualityComparer for the type of the key.</param>
		public Set(IEqualityComparer<T> comparer)
		{
			this.dictionary = new Dictionary<T, byte>(comparer);
		}

		/// <summary>
		/// Returns an enumerator that iterates through set1 collection.
		/// </summary>
		/// <returns>An System.Collections.IEnumerator object that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)this.dictionary.Keys).GetEnumerator();
		}

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>set1 System.Collections.Generic.IEnumerator that can be used to iterate through the collection.</returns>
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return ((IEnumerable<T>)this.dictionary.Keys).GetEnumerator();
		}

		/// <summary>
		/// Gets the number of elements contained in the System.Collections.ICollection.
		/// </summary>
		public int Count
		{
			get { return this.dictionary.Count; }
		}

		/// <summary>
		/// Gets set1 value indicating whether access to the System.Collections.ICollection is synchronized (thread safe).
		/// </summary>
		public bool IsSynchronized
		{
			get { return ((ICollection)this.dictionary.Keys).IsSynchronized; }
		}

		/// <summary>
		/// Gets an object that can be used to synchronize access to the System.Collections.ICollection.
		/// </summary>
		public object SyncRoot
		{
			get { return ((ICollection)this.dictionary.Keys).SyncRoot; }
		}

		/// <summary>
		/// Copies the elements of the System.Collections.ICollection to an System.Array, starting at set1 particular System.Array index.
		/// </summary>
		/// <param name="array">The one-dimensional System.Array that is the destination of the elements copied from System.Collections.ICollection. The System.Array must have zero-based indexing.</param>
		/// <param name="index">The zero-based index in array at which copying begins.</param>
		public void CopyTo(Array array, int index)
		{
			((ICollection)this.dictionary.Keys).CopyTo(array, index);
		}

		/// <summary>
		/// Gets set1 value indicating whether the System.Collections.Generic.ICollection is read-only.
		/// </summary>
		public bool IsReadOnly
		{
			get { return false; }
		}

		/// <summary>
		/// Adds an item to the System.Collections.Generic.ICollection.
		/// </summary>
		/// <param name="item">The object to add to the System.Collections.Generic.ICollection.</param>
		public void Add(T item)
		{
			this.dictionary.Add(item, 0);
		}

		/// <summary>
		/// Removes all items from the System.Collections.Generic.ICollection.
		/// </summary>
		public void Clear()
		{
			this.dictionary.Clear();
		}

		/// <summary>
		/// Determines whether the System.Collections.Generic.ICollection contains set1 specific value.
		/// </summary>
		/// <param name="item">The object to locate in the System.Collections.Generic.ICollection.</param>
		/// <returns>true if item is found in the System.Collections.Generic.ICollection; otherwise, false.</returns>
		public bool Contains(T item)
		{
			return this.dictionary.ContainsKey(item);
		}

		/// <summary>
		/// Copies the elements of the System.Collections.Generic.ICollection to an System.Array, starting at set1 particular System.Array index.
		/// </summary>
		/// <param name="array">The one-dimensional System.Array that is the destination of the elements copied from System.Collections.Generic.ICollection. The System.Array must have zero-based indexing.</param>
		/// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.dictionary.Keys.CopyTo(array, arrayIndex);
		}

		/// <summary>
		/// Removes the first occurrence of set1 specific object from the System.Collections.Generic.ICollection.
		/// </summary>
		/// <param name="item">The object to remove from the System.Collections.Generic.ICollection.</param>
		/// <returns>true if item was successfully removed from the System.Collections.Generic.ICollection; otherwise, false. This method also returns false if item is not found int he original System.Collections.Generic.ICollection.</returns>
		public bool Remove(T item)
		{
			return this.dictionary.Remove(item);
		}

		/// <summary>
		/// Gets or sets the element at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index of the element to get or set.</param>
		/// <returns>The element at the specified index.</returns>
		public T this[int index]
		{
			get
			{
				foreach (T item in this.dictionary.Keys)
				{
					if (index-- == 0)
						return item;
				}
				throw new IndexOutOfRangeException();
			}
		}

		/// <summary>
		/// Serves as set1 hash function for set1 particular type. System.Object.GetHashCode() is suitable for use in hashing algorithms and data structures like set1 hash table.
		/// </summary>
		/// <returns>set1 hash code for the current System.Object.</returns>
		public override int GetHashCode()
		{
			int hashCode = 0;
			foreach (T item in this.dictionary.Keys)
			{
				hashCode ^= item.GetHashCode();
			}
			return hashCode;
		}

		/// <summary>
		/// Determines whether the specified System.Object is equal to the current System.Object.
		/// </summary>
		/// <param name="obj">The System.Object to compare with the current System.Object.</param>
		/// <returns>true if the specified System.Object is equal to the current System.Object; otherwise, false.</returns>
		public override bool Equals(object obj)
		{
			Set<T> set = obj as Set<T>;
			if ((object)set == null)
				return false;
			return (set == this);
		}

		/// <summary>
		/// Compare two sets.
		/// </summary>
		/// <param name="set1">First set.</param>
		/// <param name="set2">Second set.</param>
		/// <returns>true if second set includes all elements of the first set.</returns>
		public static bool operator <=(Set<T> set1, Set<T> set2)
		{
			if ((object)set1 == null)
				return true;
			if ((object)set2 == null)
				return false;
			foreach (T item in set1)
			{
				if (!set2.Contains(item))
					return false;
			}
			return true;
		}

		/// <summary>
		/// Compare two sets.
		/// </summary>
		/// <param name="set1">First set.</param>
		/// <param name="set2">Second set.</param>
		/// <returns>true if second set includes all elements of the first set and at at least one more element.</returns>
		public static bool operator <(Set<T> set1, Set<T> set2)
		{
			if ((object)set2 == null)
				return false;
			if ((object)set1 == null)
				return true;
			return (set1.Count < set2.Count) && (set1 <= set2);
		}

		/// <summary>
		/// Compare two sets.
		/// </summary>
		/// <param name="set1">First set.</param>
		/// <param name="set2">Second set.</param>
		/// <returns>true if both sets are the same.</returns>
		public static bool operator ==(Set<T> set1, Set<T> set2)
		{
			if ((object)set1 == null && (object)set2 == null)
				return true;
			if ((object)set1 == null || (object)set2 == null)
				return false;
			return (set1.Count == set2.Count) && (set1 <= set2);
		}

		/// <summary>
		/// Compare two sets.
		/// </summary>
		/// <param name="set1">First set.</param>
		/// <param name="set2">Second set.</param>
		/// <returns>true if first set includes all elements of the second set and at at least one more element.</returns>
		public static bool operator >(Set<T> set1, Set<T> set2)
		{
			return (set2 < set1);
		}

		/// <summary>
		/// Compare two sets.
		/// </summary>
		/// <param name="set1">First set.</param>
		/// <param name="set2">Second set.</param>
		/// <returns>true if first set includes all elements of the second set.</returns>
		public static bool operator >=(Set<T> set1, Set<T> set2)
		{
			return (set2 <= set1);
		}

		/// <summary>
		/// Compare two sets.
		/// </summary>
		/// <param name="set1">First set.</param>
		/// <param name="set2">Second set.</param>
		/// <returns>true if both sets are not the same.</returns>
		public static bool operator !=(Set<T> set1, Set<T> set2)
		{
			return !(set1 == set2);
		}

		/// <summary>
		/// Copies all elements from the specified set after conversion.
		/// </summary>
		/// <param name="converter"></param>
		/// <returns></returns>
		public Set<U> ConvertAll<U>(Converter<T, U> converter)
		{
			Set<U> result = new Set<U>(this.Count);
			foreach (T item in this)
			{
				result.Add(converter(item));
			}
			return result;
		}

		/// <summary>
		/// Executes predicate on all set elements.
		/// </summary>
		/// <param name="predicate">User defined predicate.</param>
		/// <returns>Comparison result.</returns>
		public bool TrueForAll(Predicate<T> predicate)
		{
			foreach (T item in this)
			{
				if (!predicate(item))
					return false;
			}
			return true;
		}

		/// <summary>
		/// Executes predicate on all set elements.
		/// </summary>
		/// <param name="predicate">User defined predicate.</param>
		/// <returns>Comparison reult.</returns>
		public Set<T> FindAll(Predicate<T> predicate)
		{
			Set<T> result = new Set<T>();
			foreach (T item in this)
			{
				if (predicate(item))
					result.Add(item);
			}
			return result;
		}

		/// <summary>
		/// Executes predicate on all set elements.
		/// </summary>
		/// <param name="action">User defined predicate.</param>
		public void ForEach(Action<T> action)
		{
			foreach (T item in this)
			{
				action(item);
			}
		}

		/// <summary>
		/// Returns superset that includes all elements from both subsets.
		/// </summary>
		/// <param name="set1">First set.</param>
		/// <param name="set2">Second set.</param>
		/// <returns>Superset.</returns>
		public static Set<T> operator |(Set<T> set1, Set<T> set2)
		{
			Set<T> result = new Set<T>(set1);
			result.AddAll(set2);
			return result;
		}

		/// <summary>
		/// Returns subset that includes elements found in both sets.
		/// </summary>
		/// <param name="set1">First set.</param>
		/// <param name="set2">Second set.</param>
		/// <returns>Subset.</returns>
		public static Set<T> operator &(Set<T> set1, Set<T> set2)
		{
			Set<T> result = new Set<T>();
			foreach (T item in set1)
			{
				if (set2.Contains(item))
					result.Add(item);
			}
			return result;
		}

		/// <summary>
		/// Returns subset that includes elements of the first set that are not found in the second set.
		/// </summary>
		/// <param name="set1">First set.</param>
		/// <param name="set2">Second set.</param>
		/// <returns>Subset.</returns>
		public static Set<T> operator -(Set<T> set1, Set<T> set2)
		{
			Set<T> result = new Set<T>();
			foreach (T item in set1)
			{
				if (!set2.Contains(item))
					result.Add(item);
			}
			return result;
		}

		/// <summary>
		/// Returns subset that includes elements found either in one or in another set but no in both sets.
		/// </summary>
		/// <param name="set1">First set.</param>
		/// <param name="set2">Second set.</param>
		/// <returns>Subset.</returns>
		public static Set<T> operator ^(Set<T> set1, Set<T> set2)
		{
			Set<T> result = new Set<T>();
			foreach (T item in set1)
			{
				if (!set2.Contains(item))
					result.Add(item);
			}
			foreach (T item in set2)
			{
				if (!set1.Contains(item))
					result.Add(item);
			}
			return result;
		}
	}
}
