#include <iostream>
#include <string>

// just an interdace
class Beverage
{
	public:
					virtual double GetCost() = 0;
};

class DarkRoast : public Beverage
{
				public:
								double GetCost()
								{
									return m_cost;
								}

								DarkRoast(double cost) : m_cost(cost){}
								
								void SetCost(double cost){m_cost = cost;}

				private:
								double m_cost;
};

class Decorator : public Beverage
{
	private:
					double m_cost;
					Beverage *m_bever;

	public:
					Decorator(double cost, Beverage *pB):m_cost(cost), m_bever(pB){}

					void SetBever(Beverage *p){m_bever = p;}
					void SetCost(double cost){m_cost = cost;}
					double GetCost()
					{
						return m_bever->GetCost() + m_cost;
					}
};

class Mocha : public Decorator
{
				public:
								Mocha(double cost, Beverage *p):Decorator(cost, p){}
};

class Whip : public Decorator
{
	public:
					Whip(double cost, Beverage *p):Decorator(cost, p){}
};

int main()
{
	DarkRoast roast(1.1);
	Mocha mocha(0.2, &roast);
	Whip whip(0.3, &mocha);
	std::cout << "the final price is " << whip.GetCost() << std::endl;
}
