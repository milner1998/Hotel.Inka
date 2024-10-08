import { FuseNavigationItem } from '@fuse/components/navigation';

export const defaultNavigation: FuseNavigationItem[] = [
    {
        id: 'reserva',
        title: 'Orden de Hospedaje',
        type: 'group',
        icon: 'heroicons_outline:banknotes',
        children: [
            {
                id: 'reserva.lista',
                title: 'Lista',
                type: 'basic',
                icon: 'heroicons_outline:clipboard-document-check',
                link: '/admin/reserva/lista',
            },
        ],
    },

];
export const compactNavigation: FuseNavigationItem[] = [
    {
        id: 'reserva',
        title: 'Orden de Hospedaje',
        type: 'aside',
        icon: 'heroicons_outline:arrow-trending-down',
        children: []
    },
];
export const horizontalNavigation: FuseNavigationItem[] = [
    {
        id: 'reserva',
        title: 'Orden de Hospedaje',
        type: 'aside',
        icon: 'heroicons_outline:arrow-trending-down',
       link: '/admin/reserva'
    },

];
