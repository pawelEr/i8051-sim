namespace symulator8051.Sim.Commands
{
    interface ICommand
    {
        byte Cycles { get; } //ilosc cykli przez ktore bedzie wykonywany rozkaz
        ushort Bytes { get; } //dlugość instrukcji
        void execute(); //metoda zawierająca instrukcje wykonujące rozkaz
    }
}
