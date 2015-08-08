#include <iostream>
#include <set>
#include <string>

class Observer;
class Subject
{
  public:
    virtual void RegisterObserver(Observer* p) = 0;
    virtual void RemoveObserver(Observer* p) = 0;
    virtual void NotifyObservers() = 0;
};

class Observer
{
  private:
    std::string m_name;
  public:
    std::string GetName(){return m_name;}
    virtual void Update(Subject *pSub) = 0;
};

class WeatherData : public Subject
{
  private:
    double m_humidity;
    double m_pressure;
    double m_temperature;
    std::set<Observer*> m_observers;

  public:
    double GetHumidity(){return m_humidity;}
    double GetPressure(){return m_pressure;}
    double GetTemperature(){return m_temperature;}
    void RegisterObserver(Observer *p)
    {
      m_observers.insert(p);
    }

    void RemoveObserver(Observer *p)
    {
      std::set<Observer*>::iterator it = m_observers.find(p);
      if (it != m_observers.end())
      {
        std::cout << "Delete Observer" << p->GetName() << std::endl;
        m_observers.erase(it);
      }
      else
      {
        std::cout << "You are going to remove a non-exist element" << p->GetName() << std::endl;
      }
    }

    void NotifyObservers()
    {
      for (std::set<Observer*>::iterator it = m_observers.begin(); it != m_observers.end(); ++it)
      {
        (*it)->Update(this);
      }
    }

    void MeasurementsChanged()
    {
      NotifyObservers();
    }

    void SetMeasutement(float temperature, float humidity, float pressure)
    {
      m_temperature = temperature;
      m_humidity = humidity;
      m_pressure = pressure;
      MeasurementsChanged();
    }
};

class CurrentConditionDisplay : public Observer
{
        private:
                Subject *m_subject;

        public:
                void Update(Subject *p)
                {
                        if (p)
                        {
                          m_subject = p;
                        }
                        std::cout << "current condition update" << std::endl;
                }
};

int main(int argc, char **argv)
{
  WeatherData data;
  CurrentConditionDisplay display1;
  CurrentConditionDisplay display2;
  data.RegisterObserver(&display1);
  data.RegisterObserver(&display2);
  data.SetMeasutement(1.0f, 1.2f, 1.3f);
  data.RemoveObserver(&display2);
  data.SetMeasutement(1.3f, 1.2f, 1.3f);
  return 0;
}
