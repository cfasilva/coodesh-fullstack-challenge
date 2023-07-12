import { useEffect, useState } from 'react'
import { Header } from '../components/Header'

interface Seller {
    id: number
    name: string
}

export function Sellers() {
    const [sellers, setSellers] = useState<Seller[]>([])

    useEffect(() => {
        fetch('http://localhost:5247/api/sellers')
            .then(response => response.json())
            .then(data => setSellers(data))
    }, [])

    return (
        <>
            <Header enableNavigation />

            <div className="tableDiv">
                <table>
                    <thead>
                        <tr>
                            <th>Name</th>
                        </tr>
                    </thead>

                    <tbody>
                        {sellers.map(seller => (
                            <tr key={seller.id}>
                                <td>{seller.name}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </>
    )
}