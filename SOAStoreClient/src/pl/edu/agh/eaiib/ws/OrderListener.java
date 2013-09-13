package pl.edu.agh.eaiib.ws;

import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebService;
import javax.jws.WebParam.Mode;
import javax.jws.soap.SOAPBinding;
import javax.jws.soap.SOAPBinding.Style;
import pl.edu.agh.eaiib.entities.Order;

@WebService
@SOAPBinding(style = Style.DOCUMENT)
public interface OrderListener {
 
	@WebMethod(operationName = "OnNewOrder") 
	void OnNewOrder(@WebParam(name = "order", mode = Mode.IN) Order order);
 
}
