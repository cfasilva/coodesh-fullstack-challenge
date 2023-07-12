import { Header } from '../components/Header'
import { Upload } from '../components/Upload'

export function Home() {
    return (
        <>
            <Header enableNavigation={false} />
            <Upload />
        </>
    )
}