using CommerceFlow.Business.Abstract;
using CommerceFlow.Business.Concrete;
using CommerceFlow.ConsoleUI.Menus;
using CommerceFlow.ConsoleUI.Screens;
using CommerceFlow.DataAccess.Interfaces;
using CommerceFlow.DataAccess.Repositories;

Console.Title = "CommerceFlow - E-Ticaret Yönetim Sistemi";

ICategoryRepository categoryRepository = new CategoryRepository();
ICategoryService categoryService = new CategoryManager(categoryRepository);
CategoryScreens categoryScreens = new CategoryScreens(categoryService);
CategoryMenu categoryMenu = new CategoryMenu(categoryScreens);

ICustomerRepository customerRepository = new CustomerRepository();
ICustomerService customerService = new CustomerManager(customerRepository);
CustomerScreens customerScreens = new CustomerScreens(customerService);
CustomerMenu customerMenu = new CustomerMenu(customerScreens);

IProductRepository productRepository = new ProductRepository();
IProductService productService = new ProductManager(productRepository);
ProductScreens productScreens = new ProductScreens(productService, categoryService);
ProductMenu productMenu = new ProductMenu(productScreens);


IOrderRepository orderRepository = new OrderRepository();
IOrderService orderService = new OrderManager(orderRepository, productRepository, customerRepository);
OrderScreens orderScreens = new OrderScreens(orderService, productService, customerService);
OrderMenu orderMenu = new OrderMenu(orderScreens);


ReportScreens reportScreens = new ReportScreens(categoryService, customerService, productService, orderService);
ReportMenu reportMenu = new ReportMenu(reportScreens);

MainMenu mainMenu = new MainMenu(categoryMenu, customerMenu, productMenu, orderMenu, reportMenu);

mainMenu.Show();