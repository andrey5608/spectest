using System.Collections.Generic;
using OpenQA.Selenium;

namespace SpecTest
{
    public class DictionaryExtensions
    {
        private Dictionary<string, IWebElement> elements;

        public Dictionary<string, IWebElement> Elements { get => elements; set => elements = value; }

        public IWebElement GetFromDictionaryByName(string name)
        {
            return Elements.TryGetValue(name, out var element) ? element : throw new NotFoundException($"Can not find element {name} in page object");
        }
    }
}
