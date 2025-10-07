using BT2_Nhom3_23WebC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BT2_Nhom3_23WebC.Controllers
{
    public class FAQsController : Controller
    {
        public IActionResult Index()
        {
            var model = new FAQsViewModel
            {
                Title = "FAQs",
                Items = new List<FAQItem>
            {
                new FAQItem
                {
                    Question = "How do I know if my order has been placed?",
                    Answers = new List<string>
                    {
                        "You will receive an email confirming that your order has been received. If you do not receive an email confirmation, please login to see your order status. Validate <a href=\"http://validator.w3.org/check?uri=referer\" rel=\"nofollow\"><strong>XHTML</strong></a> &amp; <a href=\"http://jigsaw.w3.org/css-validator/check/referer\" rel=\"nofollow\"><strong>CSS</strong></a>."
                    }
                },
                new FAQItem
                {
                    Question = "When will my order be shipped?",
                    Answers = new List<string>
                    {
                        "Please read our shipping policy. Click <a href=\"#\">here</a>"
                    }
                },
                new FAQItem
                {
                    Question = "What payment methods do you accept?",
                    Answers = new List<string>
                    {
                        "PayPal and 2Checkout (2CO)"
                    }
                },
                new FAQItem
                {
                    Question = "Can I return or exchange my purchase if I don't like it?",
                    Answers = new List<string>
                    {
                        "Please read our exchange policy. Click <a href=\"#\">here</a>"
                    }
                },
                new FAQItem
                {
                    Question = "How do I know if online ordering is secured?",
                    Answers = new List<string>
                    {
                        @"Protecting your information is a top priority for this site. We use Secure Sockets Layer (SSL) to encrypt your credit card number, name and address, so only this site is able to decode your information. SSL is the industry standard method for computers to communicate securely without risk of data interception, manipulation or recipient impersonation. To be sure your connection is secure; when you are in the Shopping Cart, look at the lower corner of your browser window. If you see an unbroken key or closed lock, the SSL is active and your information is secure. Since most of the customers are still uncomfortable with providing your credit card online, we use PayPal and 2CheckOut services and they do not need to give out credit card information.",
                        @"This site is registered with HackerGuardian. HackerGuardian certification for a hacker free website and a Credit Card TrustLogo confirming your trustworthiness to take credit card details online."
                    }
                },
                new FAQItem
                {
                    Question = "What is your privacy policy?",
                    Answers = new List<string>
                    {


                        @"This website respects your privacy and ensure that you understand what information we need to complete your order, and what information you can choose to share with us and with our marketing partners. For complete information on our privacy policy, please visit our  <a href=\""#\"">Privacy Policy</a> page.",
                    
                    }
                }
            }
            };

            return View(model);
        }
    }
}
