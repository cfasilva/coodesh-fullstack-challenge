import { useEffect, useState } from 'react'
import { Header } from '../components/Header'

interface Product {
    id: number
    name: string
}

export function Products() {
    const [products, setProducts] = useState<Product[]>([])

    useEffect(() => {
        fetch('http://localhost:5247/api/products')
            .then(response => response.json())
            .then(data => setProducts(data))
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
                        {products.map(product => (
                            <tr key={product.id}>
                                <td>{product.name}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </>
    )
}