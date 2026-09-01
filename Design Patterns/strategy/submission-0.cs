public class Person {
    private string lastName;
    private int age;
    private bool married;

    public Person(string lastName, int age, bool married) {
        this.lastName = lastName;
        this.age = age;
        this.married = married;
    }

    public string getLastName() {
        return lastName;
    }

    public int getAge() {
        return age;
    }

    public bool isMarried() {
        return married;
    }
}

public interface IPersonFilter {
    bool apply(Person person);
}

public class AdultFilter : IPersonFilter {
    public bool apply(Person person) {
        return person.getAge() >= 18;
    }
}

public class SeniorFilter : IPersonFilter {
    public bool apply(Person person) {
        return person.getAge() >= 65;
    }
}

public class MarriedFilter : IPersonFilter {
    public bool apply(Person person) {
        return person.isMarried();
    }
}

public class PeopleCounter {
    private IPersonFilter filter;

    public void setFilter(IPersonFilter filter) {
        this.filter = filter;
    }

    public int count(List<Person> people) {
        int count = 0;
        foreach (Person person in people){
            if (filter.apply(person)){
                count++;
            }
        }
        return count;
    }
}
