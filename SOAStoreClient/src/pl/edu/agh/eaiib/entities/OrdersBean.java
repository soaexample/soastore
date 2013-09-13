package pl.edu.agh.eaiib.entities;

import javax.faces.bean.ApplicationScoped;
import javax.faces.bean.ManagedBean;

import pl.edu.agh.eaiib.OrdersController;

import java.io.Serializable;
 
@ManagedBean(eager=true)
@ApplicationScoped
public class OrdersBean implements Serializable {
 
	private static final long serialVersionUID = 1L;
	
	public Order[] getOrders() {
		return OrdersController.getInstance().getOrders();
	}
	
	public void removeOrder(Order o) {
		OrdersController.getInstance().removeOrder(o);
	}
	
}