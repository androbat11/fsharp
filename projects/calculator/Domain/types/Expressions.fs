namespace DomainTypes

type BinaryOperator =
    | Add
    | Sustract
    | Multiply
    | Devide

type UnaryOperator =
    | Negate
    | Identity

type NumberExpression =
    | Int of int
    | Float of float

type Expression =
    | Number of NumberExpression
    | BinaryOp of BinaryOperator * Expression * Expression
    | UnaryOp of UnaryOperator