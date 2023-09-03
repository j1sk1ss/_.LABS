using System;
using System.Collections.Generic;
using System.Linq;
using CS_LABS.LABS.SIXTH_LAB.OBJECTS.FIRST_TASK;
using CS_LABS.LABS.SIXTH_LAB.OBJECTS.SECOND_TASK;
using CS_LABS.LABS.SIXTH_LAB.OBJECTS.THIRD_TASK;

namespace CS_LABS.LABS.SIXTH_LAB;

public class Sixth : Quest {
    public Sixth() {
        Quests = new List<Action> {
            FirstTask,
            SecondTask
        };
    }
    
    /// <summary>
    /// Для каждого месяца определить суммарную продолжительность занятий всех клиентов за
    /// все годы (вначале выводить суммарную продолжительность, затем номер месяца). Если
    /// данные о некотором месяце отсутствуют, то для этого месяца вывести 0 Сведения о
    /// каждом месяце выводить на новой строке и упорядочивать по убыванию суммарной
    /// продолжительности, а при равной продолжительности — по возрастанию номера месяца.
    /// </summary>
    private void FirstTask() {
        var clients = new List<Client>();
        for (var i = 0; i < 100; i++) 
            clients.Add(
                new Client {
                    Code     = (ulong)new Random(DateTime.Now.Millisecond).Next(999999),
                    Duration = new Random(DateTime.Now.Second + i).Next(1, 6),
                    Mouth    = new Random(DateTime.UtcNow.Month * i).Next(1, 12),
                    Year     = new Random(i).Next(2020, 2023)
                }
            );

        var mouths = Enumerable.Range(1, 13)
            .Select(mouth =>
                new {mouth, Sum = clients.Where(client => client.Mouth == mouth).Sum(client => client.Duration)})
            .OrderByDescending(tuple => tuple.Sum);

        foreach (var mouth in mouths) 
            Console.WriteLine($"Mouth: {mouth.mouth} | Summary duration: {mouth.Sum}");
    }

    /// <summary>
    /// Найти годы, для которых число абитуриентов было не меньше среднего значения по всем
    /// годам (вначале указывать число абитуриентов для данного года, затем год). Сведения о
    /// каждом годе выводить на новой строке и упорядочивать по убыванию числа
    /// абитуриентов, а для совпадающих чисел — по возрастанию номера года.
    /// </summary>
    private void SecondTask() {
        var students = new List<Student>();
        for (var i = 0; i < 100; i++) 
            students.Add(
                new Student {
                    School  = (ulong)new Random(DateTime.Now.Millisecond).Next(999999),
                    Surname = new Random(DateTime.Now.Second + i).Next(1000, 6000).ToString(),
                    Year    = new Random(i * i).Next(2010, 2023)
                }
            );

        var startYear = students.Min(student => student.Year);
        var endYear = students.Max(student => student.Year);
        
        var average = students.Count / (endYear - startYear);
        var years = Enumerable.Range(startYear, endYear - startYear)
            .Select(year => new {Count = students.Count(student => student.Year == year), Year = year})
            .Where(student => student.Count >= average)
            .OrderByDescending(studentCount => studentCount.Count);

        foreach (var year in years) 
            Console.WriteLine($"Students count: {year.Count} | Year: {year.Year}");
    }

    /// <summary>
    /// Задолженность указывается в виде дробного числа (целая часть — рубли, дробная часть
    /// — копейки). В каждом подъезде на каждом этаже располагаются по 4 квартиры. Для
    /// каждого из 9 этажей дома вывести сведения о задолжниках, живущих на этом этаже:
    /// число задолжников, номер этажа, суммарная задолженность для жильцов этого этажа
    /// (выводится с двумя дробными знаками). Сведения о каждом этаже выводить на отдельной
    /// строке и упорядочивать по возрастанию числа задолжников, а для совпадающих чисел —
    /// по возрастанию этажа. Если на каком-либо этаже задолжники отсутствуют, то данные об
    /// этом этаже не выводить.
    /// </summary>
    private void ThirdTask() {
        var inhabitants = new List<Inhabitant>();
        for (var i = 0; i < 145; i++) 
            inhabitants.Add(
                new Inhabitant {
                    Apartment  = i,
                    Surname    = new Random(DateTime.Now.Second + i).Next(1000, 6000).ToString(),
                    Debt       = new Random(i * i).Next(10, 100000) / 100d
                }
            );
        
        
    }
}