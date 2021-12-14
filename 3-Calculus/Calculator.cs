using ComplexAlgebra;
using System;

namespace Calculus
{
    /// <summary>
    /// A calculator for <see cref="Complex"/> numbers, supporting 2 operations ('+', '-').
    /// The calculator visualizes a single value at a time.
    /// Users may change the currently shown value as many times as they like.
    /// Whenever an operation button is chosen, the calculator memorises the currently shown value and resets it.
    /// Before resetting, it performs any pending operation.
    /// Whenever the final result is requested, all pending operations are performed and the final result is shown.
    /// The calculator also supports resetting.
    /// </summary>
    ///
    /// HINT: model operations as constants
    /// HINT: model the following _public_ properties methods
    /// HINT: - a property/method for the currently shown value
    /// HINT: - a property/method to let the user request the final result
    /// HINT: - a property/method to let the user reset the calculator
    /// HINT: - a property/method to let the user request an operation
    /// HINT: - the usual ToString() method, which is helpful for debugging
    /// HINT: - you may exploit as many _private_ fields/methods/properties as you like
    ///
    /// TODO: implement the calculator class in such a way that the Program below works as expected
    class Calculator
    {
        public const char OperationPlus = '+';
        public const char OperationMinus = '-';

        private char _operation;
        public char Operation
        {
            get { return _operation; }
            set
            {
                _operation = value;
                if (_memory == null)
                {
                    _memory = Value;
                    Value = null;
                }
                else
                {
                    switch (_operation)
                    {
                        case OperationPlus:
                            _memory = _memory.Plus(Value);
                            break;
                        case OperationMinus:
                            _memory = _memory.Minus(Value);
                            break;
                        default:
                            break;
                    }
                    Value = null;
                }
            }
        }

        private Complex _memory;
        public Complex Value
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Value + Operation.ToString();
        }

        public void ComputeResult()
        {
            Operation = _operation;
            Value = _memory;
        }

        public void Reset()
        {
            _memory = null;
            Value = null;
            Operation = '0';
        }
        // TODO fill this class

    }
}