using Antlr4.Runtime.Misc;

namespace Compilador;

public class BasicFortallVisitor : FortallBaseVisitor<object?>
{
    private Dictionary<string, object?> Variables { get; } = new();

    public override object? VisitAssignment(FortallParser.AssignmentContext context)
    {
        var varName = context.ID().GetText();

        var value = Visit(context.expression());

        Variables[varName] = value;

        return null;
    }

    public override object? VisitWhileBlock(FortallParser.WhileBlockContext context)
    {
        while (true)
        {
            var condition = Visit(context.expression());
            if (condition is not bool conditionBool || !conditionBool)
                break;

            Visit(context.block());
        }
        return null;
    }

    public override object? VisitIfBlock(FortallParser.IfBlockContext context)
    {
        var condition = Visit(context.expression());
        if (IsTrue(condition))
        {
            return Visit(context.block());
        }
        else
        {
            foreach (var elseIfContext in context.elseIfBlock())
            {
                if (elseIfContext.ifBlock() != null)
                {
                    var result = Visit(elseIfContext.ifBlock());
                    if (!(result is null)) 
                        return result;
                }
                else
                {
                    return Visit(elseIfContext.block());
                }
            }
        }
        
        // Return null if no blocks were executed
        return null;
    }

    private bool IsTrue(object? value)
    {
        if (value is bool b)
            return b;

        if (value is int i)
            return i != 0;

        if (value is float f)
            return f != 0.0f;

        if (value is string s)
            return !string.IsNullOrEmpty(s);

        return value != null; 
    }

    private bool IsFalse(object? value) => !IsTrue(value);

    public override object? VisitPrint(FortallParser.PrintContext context)
    {
        var value = Visit(context.expression());
        Console.WriteLine(value);
        return null;
    }

    public override object? VisitInput(FortallParser.InputContext context)
    {
        var varName = context.ID().GetText();

        Console.Write($"Digite um valor para {varName}: ");
        var input = Console.ReadLine();

        if (int.TryParse(input, out var intValue))
        {
            Variables[varName] = intValue;
        }
        else if (float.TryParse(input, out var floatValue))
        {
            Variables[varName] = floatValue;
        }
        else if (bool.TryParse(input, out var boolValue))
        {
            Variables[varName] = boolValue;
        }
        else
        {
            Variables[varName] = input; // Treat as string
        }

        return null;
    }

    public override object? VisitConstant(FortallParser.ConstantContext context)
    {
        if (context.INTEGER() is { } i)
            return int.Parse(i.GetText());

        if (context.FLOAT() is { } f)
            return float.Parse(f.GetText());

        if (context.STRING() is { } s)
            return s.GetText()[1..^1];

        if (context.BOOL() is { } b)
            return b.GetText() == "true";

        if (context.NULL() is { })
            return null;

        throw new NotImplementedException();
    }

    public override object? VisitIdentifierExpression(FortallParser.IdentifierExpressionContext context)
    {
        var varName = context.ID().GetText();

        if (!Variables.ContainsKey(varName))
        {
            throw new Exception($"Vari�vel {varName} n�o est� definida");
        }

        return Variables[varName];
    }

    public override object VisitNegationExpression(FortallParser.NegationExpressionContext context)
    {
        var value = Visit(context.expression());

        if (value is bool b)
            return !b;

        if (value is int i)
            return -i;

        if (value is float f)
            return -f;

        throw new Exception($"Nao e possivel aplicar negacao a um valor do tipo {value?.GetType()}.");
    }

    public override object? VisitMultiplicativeExpression(FortallParser.MultiplicativeExpressionContext context)
    {
        var left = Visit(context.expression(0));
        var right = Visit(context.expression(1));

        var op = context.multOp().GetText();
        return op switch
        {
            "*" => Multiply(left, right),
            "/" => Divide(left, right),
            "%" => Modulo(left, right),
            _ => throw new NotImplementedException()
        };
    }
    public override object? VisitAdditiveExpression(FortallParser.AdditiveExpressionContext context)
    {
        var left = Visit(context.expression(0));
        var right = Visit(context.expression(1));

        var op = context.addOp().GetText();
        return op switch
        {
            "+" => Add(left, right),
            "-" => Subtract(left, right),
            _ => throw new NotImplementedException()
        };
    }

    public override object? VisitComparisonExpression(FortallParser.ComparisonExpressionContext context)
    {
        var left = Visit(context.expression(0));
        var right = Visit(context.expression(1));

        var op = context.compOp().GetText();
        return op switch
        {
            "<" => LessThan(left, right),
            ">" => LessThan(right, left), 
            "<=" => LessOrEqualThan(left, right),
            ">=" => LessOrEqualThan(right, left), 
            "==" => Equals(left, right),
            "!=" => !Equals(left, right),
            _ => throw new NotImplementedException()
        };
    }

    private bool LessThan(object? left, object? right)
    {
        if (left is int l && right is int r)
            return l < r;

        if (left is float lf && right is float rf)
            return lf < rf;

        if (left is int lInt && right is float rFloat)
            return lInt < rFloat;

        if (left is float lFloat && right is int rInt)
            return lFloat < rInt;

        throw new Exception($"Nao e possivel comparar valores do tipo {left?.GetType()} e {right?.GetType()} com '<'.");
    }

    private bool LessOrEqualThan(object? left, object? right)
    {
        if (left is int l && right is int r)
            return l <= r;

        if (left is float lf && right is float rf)
            return lf <= rf;

        if (left is int lInt && right is float rFloat)
            return lInt <= rFloat;

        if (left is float lFloat && right is int rInt)
            return lFloat <= rInt;

        throw new Exception($"Nao e possivel comparar valores do tipo {left?.GetType()} e {right?.GetType()} com '<='."); 
    }

    public override object? VisitParenthesizedExpression(FortallParser.ParenthesizedExpressionContext context)
    {
        return Visit(context.expression());
    }

    public override object VisitBooleanExpression(FortallParser.BooleanExpressionContext context)
    {
        var left = Visit(context.expression(0));
        var right = Visit(context.expression(1));
        var op = context.boolOp().GetText();
        return op switch
        {
            "and" => And(left, right),
            "or" => Or(left, right),
            "&&" => And(left, right),
            "||" => Or(left, right),
            _ => throw new NotImplementedException()
        };
    }

    private object Or(object? left, object? right)
    {
        if (left is bool l && right is bool r)
            return l || r;

        if (left is int lInt && right is int rInt)
            return lInt != 0 || rInt != 0;

        if (left is float lFloat && right is float rFloat)
            return lFloat != 0.0f || rFloat != 0.0f;

        if (left is string lStr && right is string rStr)
            return !string.IsNullOrEmpty(lStr) || !string.IsNullOrEmpty(rStr);
        
        throw new NotImplementedException();
    }

    private object And(object? left, object? right)
    {
        if (left is bool l && right is bool r)
            return l && r;
        
        if (left is int lInt && right is int rInt)
            return lInt != 0 && rInt != 0;

        if (left is float lFloat && right is float rFloat)
            return lFloat != 0.0f && rFloat != 0.0f;

        if (left is string lStr && right is string rStr)
            return !string.IsNullOrEmpty(lStr) && !string.IsNullOrEmpty(rStr);
            
        throw new NotImplementedException();
    }

    private object? Multiply(object? left, object? right)
    {
        if (left is int l && right is int r)
            return l * r;

        if (left is float lf && right is float rf)
            return lf * rf;

        if (left is int lInt && right is float rFloat)
            return lInt * rFloat;

        if (left is float lFloat && right is int rInt)
            return lFloat * rInt;

        throw new Exception($"Nao e possivel multiplicar valores do tipo {left?.GetType()} e {right?.GetType()}.");
    }

    private object? Divide(object? left, object? right)
    {
        if (left is int l && right is int r)
            return l / r;

        if (left is float lf && right is float rf)
            return lf / rf;

        if (left is int lInt && right is float rFloat)
            return lInt / rFloat;

        if (left is float lFloat && right is int rInt)
            return lFloat / rInt;

        throw new Exception($"Nao e possivel dividir valores do tipo {left?.GetType()} e {right?.GetType()}.");
    }

    private object? Modulo(object? left, object? right)
    {
        if (left is int l && right is int r)
            return l % r;

        if (left is float lf && right is float rf)
            return lf % rf;

        if (left is int lInt && right is float rFloat)
            return lInt % rFloat;

        if (left is float lFloat && right is int rInt)
            return lFloat % rInt;

        throw new Exception($"Nao e possivel calcular o modulo de valores do tipo {left?.GetType()} e {right?.GetType()}.");
    }

    private object? Add(object? left, object? right)
    {
        if (left is int l && right is int r)
            return l + r;

        if (left is float lf && right is float rf)
            return lf + rf;

        if (left is int lInt && right is float rFloat)
            return lInt + rFloat;

        if (left is float lFloat && right is int rInt)
            return lFloat + rInt;

        if (left is string ls && right is string rs)
            return ls + rs;
            
        if (left is string lStrInt && right is int rIntStr)
            return lStrInt + rIntStr.ToString();

        if (left is int lIntStr && right is string rStrInt)
            return lIntStr.ToString() + rStrInt;

        throw new Exception($"Nao e possivel adicionar valores do tipo {left?.GetType()} e {right?.GetType()}.");
    }

    private object? Subtract(object? left, object? right)
    {
        if (left is int l && right is int r)
            return l - r;

        if (left is float lf && right is float rf)
            return lf - rf;

        if (left is int lInt && right is float rFloat)
            return lInt - rFloat;

        if (left is float lFloat && right is int rInt)
            return lFloat - rInt;

        throw new Exception($"Nao e possivel subtrair valores do tipo {left?.GetType()} e {right?.GetType()}.");
    }
}