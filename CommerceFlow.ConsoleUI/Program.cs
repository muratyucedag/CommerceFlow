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
ProductScreens productScreens = new ProductScreens(productService,categoryService);
ProductMenu productMenu = new ProductMenu(productScreens);

MainMenu mainMenu = new MainMenu(categoryMenu, customerMenu, productMenu);

mainMenu.Show();