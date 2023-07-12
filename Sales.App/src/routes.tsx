import { createBrowserRouter } from 'react-router-dom'
import { Home } from './pages/Home'
import { Transactions } from './pages/Transactions'
import { Products } from './pages/Products'
import { Sellers } from './pages/Sellers'

export const router = createBrowserRouter([
    {
        path: '/',
        element: <Home />
    },
    {
        path: '/transactions',
        element: <Transactions />
    },
    {
        path: '/products',
        element: <Products />
    },
    {
        path: '/sellers',
        element: <Sellers />
    },
])