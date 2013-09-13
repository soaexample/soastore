package pl.edu.agh.eaiib.entities;

import java.io.Serializable;

public class Order implements Serializable {
	
	private static final long serialVersionUID = 1L;
	
	private int id;
	private OrderEntity [] entities;
	private String address;
	
	public int getId() {
		return id;
	}
	
	public void setId(int id) {
		this.id = id;
	}
	
	public OrderEntity [] getEntities() {
		return entities;
	}
	
	public void setEntities(OrderEntity [] entities) {
		this.entities = entities;
	}
	
	public String getAddress() {
		return address;
	}
	
	public void setAddress(String address) {
		this.address = address;
	}
	
	public int hashCode()
	{
		return id;
	}
	
	public boolean equals(Object obj) {
	    if (obj == null) {
	        return false;
	    }
	    if (!obj.getClass().equals(Order.class)) {
	        return false;
	    }
	    return id == ((Order) obj).id;
	}

}
