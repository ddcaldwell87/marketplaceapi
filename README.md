# marketplaceapi
Eleven Fifty Academy Red Badge group Back-End Project.

This project is designed to be a marketplace where users can sign up as a customer or a retailer. Retailers can list their products. Everyone can see all products available. Development currently in progress.

- [Api endpoints](https://efamarketplacewebapi.azurewebsites.net/Help)
- [Live Site](https://dsbh-marketplace.herokuapp.com/)

## Code Screenshots
Snippet of service layer.
```c#
        public CustomerDetails GetCustomerById(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == customerId && e.OwnerId == _userId);
                return
                    new CustomerDetails
                    {
                        OwnerId = entity.OwnerId,
                        CustomerId = entity.CustomerId,
                        CustomerFirstName = entity.CustomerFirstName,
                        CustomerLastName = entity.CustomerLastName,
                        CustomerEmail = entity.CustomerEmail,
                        CustomerPhone = entity.CustomerPhone,
                        CustomerStreetAddress = entity.CustomerStreetAddress,
                        State = entity.State,
                        City = entity.City,
                        Zip = entity.Zip
                    };
            }
        }
```

Controller
```c#
        public IHttpActionResult Post(ProductCreate product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProductService();

            if (!service.CreateProduct(product))
                return InternalServerError();

            return Ok();
        }
```

Assigning roles at registration
```c#
        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };

            IdentityResult result = await UserManager.CreateAsync(user, model.Password);

            var userResult = await UserManager.FindByEmailAsync(model.Email);

            if(model.Role == "Customer")
            {
                var roleResult = await UserManager.AddToRoleAsync(userResult.Id, "Customer");
            }

            if(model.Role == "Retailer")
            {
                var roleResult = await UserManager.AddToRoleAsync(userResult.Id, "Retailer");
            }

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }
```
