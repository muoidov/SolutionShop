﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionShop.ViewModel.Sales
{
    public class CheckoutRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<OrderDetailVm> OrderDetails { get; set; } = new List<OrderDetailVm>();
    }
}
