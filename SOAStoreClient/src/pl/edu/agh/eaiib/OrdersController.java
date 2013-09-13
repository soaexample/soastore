package pl.edu.agh.eaiib;

import java.util.HashSet;
import java.util.Set;

import pl.edu.agh.eaiib.entities.Order;

public final class OrdersController {
	 
    private static volatile OrdersController instance = null;
 
    private OrdersController() {
    	orders = new HashSet<Order>();
    }
    
    public static OrdersController getInstance() {
        if (instance == null) {
            synchronized (OrdersController.class) {
                if (instance == null) {
                    instance = new OrdersController();
                }
            }
        }
        return instance;
    }
    
    public synchronized Order[] getOrders() {
    	Order[] o = orders.toArray(new Order[orders.size()]);
		return o;
    }
    
    public synchronized void addOrder(Order order) {
		orders.add(order);
    }
    
    public synchronized void removeOrder(Order order) {
		orders.remove(order);
    }
 
    private Set<Order> orders = null;
 
}
