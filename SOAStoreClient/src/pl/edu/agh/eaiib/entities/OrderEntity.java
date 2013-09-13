package pl.edu.agh.eaiib.entities;

import java.io.Serializable;

public class OrderEntity implements Serializable {
	
	private static final long serialVersionUID = 1L;

	private String product;
	private int quantity;
	
	public String getProduct() {
		return product;
	}
	
	public void setProduct(String product) {
		this.product = product;
	}
	
	public int getQuantity() {
		return quantity;
	}
	
	public void setQuantity(int quantity) {
		this.quantity = quantity;
	}
	
}
