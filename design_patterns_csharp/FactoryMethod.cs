using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_patterns_csharp
{
    class FactoryMethod
    {
    }

    // The product abstract class
    abstract class Product
    {
        
    }//end of abstract class Product

    class ConcreteProductA : Product
    {

    }//end of class ConcreteProductA

    class ConcreteProductB : Product
    {

    }//end of class ConcreteProductB

    abstract class Creator
    {
        public abstract Product FactoryMethod();
    }//abstract class Creator

    class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    class ConcreateCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }

    // Real-world example
    // Abstract Product
    abstract class Page
    {

    }

    // Concrete Products
    class SkillsPage : Page { }
    class EducationPage : Page { }
    class ExperiencePage : Page { }
    class IntroductionPage : Page { }
    class ResultPage : Page { }
    class ConclusionPage : Page { }
    class SummaryPage : Page { }
    class BibliographyPage : Page { }

    // Creator class
    abstract class Document
    {
        private List<Page> m_pages = new List<Page>();

        public Document()
        {
            this.CreatePages();
        }

        public List<Page> pages
        {
            get { return m_pages; }
        }

        public abstract void CreatePages();
    }

    //Concreate Creator class
    class Resume : Document
    {
        public override void CreatePages()
        {
            pages.Add(new SkillsPage());
            pages.Add(new EducationPage());
            pages.Add(new ExperiencePage());
        }
    }

    //Concrete Creator class
    class Report : Document
    {
        public override void CreatePages()
        {
            pages.Add(new IntroductionPage());
            pages.Add(new ResultPage());
            pages.Add(new ConclusionPage());
            pages.Add(new SummaryPage());
        }
    }
}
