package pl.edu.agh.eaiib.ws;

import javax.jws.WebService;

import pl.edu.agh.eaiib.OrdersController;
import pl.edu.agh.eaiib.entities.Order;

@WebService(endpointInterface = "pl.edu.agh.eaiib.ws.OrderListener")
public class OrderListenerImpl implements OrderListener {
	
	private OrdersController ordersController = null;
	
	public OrderListenerImpl()
	{
		ordersController = OrdersController.getInstance();
	}
	
	@Override
	public void OnNewOrder(Order order) {
		ordersController.addOrder(order);
	}


}
