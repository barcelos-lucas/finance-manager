import { useEffect, useState } from 'react'
import api from '../api/api'
import { SaldoResponse } from '../types/Saldo'

export function useSaldoMensal(ano: number, mes: number) {
    const [saldo, setSaldo] = useState<SaldoResponse | null>(null)
    const [loading, setLoading] = useState(true)

    useEffect(() => {
        const fetchSaldo = async () => {
            try {
                const res = await api.get<SaldoResponse>(`/api/relatorios/saldo-mes/${ano}/${mes}`)
                setSaldo(res.data)
            } catch (err) {
                console.error(err)
            } finally {
                setLoading(false)
            }
        }

        fetchSaldo()
    }, [ano, mes])

    return { saldo, loading }
}
