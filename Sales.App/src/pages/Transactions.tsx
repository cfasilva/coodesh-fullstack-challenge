import { useEffect, useState } from 'react'
import { Header } from '../components/Header'

interface Transaction {
    id: number
    type: string
    date: string
    product: {
        id: number
        name: string
    }
    value: number
    seller: {
        id: number
        name: string
    }
}

export function Transactions() {
    const [transactions, setTransactions] = useState<Transaction[]>([])
    const [total, setTotal] = useState<number>(0)

    useEffect(() => {
        fetch('http://localhost:5247/api/transactions')
            .then(response => response.json())
            .then(data => {
                setTotal(data.total)
                setTransactions(data.transactions)
            })
    }, [])

    return (
        <>
            <Header />

            <h2>Total: R${total}</h2>
            
            <div className="tableDiv">
                <table>
                    <thead>
                        <tr>
                            <th>Type</th>
                            <th>Date</th>
                            <th>Product</th>
                            <th>Value</th>
                            <th>Seller</th>
                        </tr>
                    </thead>

                    <tbody>
                        {transactions.map(transaction => (
                            <tr key={transaction.id}>
                                <td>{transaction.type}</td>
                                <td>{transaction.date}</td>
                                <td>{transaction.product.name}</td>
                                <td>R${transaction.value}</td>
                                <td>{transaction.seller.name}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </>
    )
}