﻿/*
 * NetLua by Francesco Bertolaccini
 * Project inspired by AluminumLua, a project by Alexander Corrado
 * (See his repo at http://github.com/chkn/AluminumLua)
 * 
 * NetLua - a managed implementation of the Lua dynamic programming language
 * 
 * Ast.cs
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lua.Ast
{
    public interface IStatement
    { }

    public interface IExpression
    { }

    public interface IAssignable : IExpression
    { }

    public class Variable : IExpression, IAssignable
    {
        // Prefix.Name
        public IExpression Prefix;
        public string Name;
    }

    public class Argument
    {
        public string Name;
    }

    public class StringLiteral : IExpression
    {
        public string Value;
    }

    public class NumberLiteral : IExpression
    {
        public double Value;
    }

    public class NilLiteral : IExpression
    { }

    public class BoolLiteral : IExpression
    {
        public bool Value;
    }

    public class FunctionCall : IStatement, IExpression
    {
        public IExpression Function;
        public List<IExpression> Arguments;
    }

    public class TableAccess : IExpression, IAssignable
    {
        // Expression[Index]
        public IExpression Expression;
        public IExpression Index;
    }

    public class FunctionDefinition : IExpression
    {
        // function(Arguments) Body end
        public List<Argument> Arguments;
        public Block Body;
    }

    public class Assignment : IStatement
    {
        // Var1, Var2, Var3 = Exp1, Exp2, Exp3
        //public Variable[] Variables;
        //public IExpression[] Expressions;

        public IAssignable Variable;
        public IExpression Expression;
    }

    public class Return : IStatement
    {
        public IExpression Expression;
    }

    public class LocalAssignment : Assignment
    {
    }

    public class Block : IStatement
    {
        public List<IStatement> Statements;
    }
}
