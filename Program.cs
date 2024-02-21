using System.Text;

namespace pr1;
internal class Program
{
	static void Main()
	{
		Console.InputEncoding = Encoding.UTF8;
		Console.OutputEncoding = Encoding.UTF8;

		Console.WriteLine("\n================ Завдання 1 ====================\n");
		Console.Write("Введіть значення напруги (у Вольтах): ");
		double U = Convert.ToDouble(Console.ReadLine());
		Console.Write("\nВведіть значення опору (в Омах): ");
		double R = Convert.ToDouble(Console.ReadLine());

		Physics p1 = new Physics(U, R);
		p1.Info();
		double I = p1.GetСurrent();
		Console.Write($"\nОбчислення значення струму (в Амперах): {I}\n");

		Console.WriteLine("\n================ Завдання 2 ====================\n");
		Console.WriteLine("Введіть 4 цілих числа: ");
		int[] num = new int[4];
		for (int i = 0; i < 4; i++) {
			num[i] = Convert.ToInt32(Console.ReadLine());
		}
		Numbers num1 = new Numbers();
		num1.Info();
		num1.Average();
		num1.Max();

		Numbers num2 = new Numbers(num[0], num[1], num[2], num[3]);
		num2.Info();
		num2.Average();
		num2.Max();

		Console.WriteLine("\n================ Завдання 3 ====================\n");
		Console.Write("Введіть кількість секунд: ");
		int seconds = Convert.ToInt32(Console.ReadLine());

		Work w1 = new Work(U, R, seconds);
		double W = w1.GetWork();
		Console.Write($"\nОбчислення роботи (у Джоулях): {W}\n");
		w1.Info();
	}
}
public class Physics {
	protected double _voltage;
	protected double _resistance;
	public Physics(double voltage, double resistance)
	{
		_voltage = voltage;
		_resistance = resistance;
	}
	public virtual void Info() {
		Console.WriteLine($"\nНапруга (у Вольтах): {_voltage}, опір (в Омах): {_resistance}");
	}
	public double GetСurrent() => _voltage / _resistance;
}
public class Work : Physics {
	private int _seconds;
	public Work(double voltage, double resistance, int seconds) : base(voltage, resistance)
	{
		_seconds = seconds;
	}
	public double GetWork() {
		double W = _voltage * GetСurrent() * _seconds;
		return W;
	}
	public override void Info()
	{
		Console.WriteLine($"\nНапруга (у Вольтах): {_voltage}; опір (в Омах): {_resistance}; ток (в Амперах): {GetСurrent()}; робота (у Джоулях) {GetWork()}.");
	}
}
public class Numbers {
	private int _a, _b, _c, _d;
	public Numbers()
	{
		_a = 2;
		_b = 4;
		_c = 6;
		_d = 8;
	}
	public Numbers(int a, int b, int c, int d) 
	{
		_a = a;
		_b = b;
		_c = c;
		_d = d;
	}
	~Numbers() 
	{
		Console.WriteLine("Об'єкт було знищено");
	}
	public void Info() {
		Console.WriteLine($"a = {_a}, b = {_b}, c = {_c}, d = {_d}");
	}
	public double Average() {
		double avg = Math.Round(((double)_a + _b + _c + _d) / 4, 2);
		Console.WriteLine($"Average = {avg}");
		return avg;
	}
	public int Max() {
		int max1 = Math.Max(_a, _b);
		int max2 = Math.Max(_c, _d);
		int max = Math.Max(max1, max2);
		Console.WriteLine($"Max = {max}");
		return max;
	}
}
