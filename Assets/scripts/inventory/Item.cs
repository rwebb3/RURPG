using UnityEngine;
using System.Collections;

public class Item{

	public string name;
	public string id;
	public string type;

	public Item(string _name, string _id, string _type){
		this.name = _name;
		this.id = _id;
		this.type = _type;
	}
	
	//Items are equal if the fields are equal
	public bool Equals(Item other){
		return (this.name.Equals(other.name) &&
				this.id.Equals(other.id)     &&
				this.type.Equals(other.type));
	}
	
	//create a hash code based on hash codes from fields.
	public int GetHashcode(){
		int hash = 17;
		hash = (hash * 11) + this.name.GetHashCode();
		hash = (hash * 11) + this.id.GetHashCode();
		hash = (hash * 11) + this.type.GetHashCode();
		return hash;
	}
	
}
